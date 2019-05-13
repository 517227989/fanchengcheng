using BCL.DataAccess;
using BCL.ToolLib;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.XAI;
using BCL.ToolLibWithApp.XAI.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAI.Business.Enum;
using XAI.Business.Model;

namespace XAI.Business
{
    public class BusinessBIDU : IBusiness
    {
        /// <summary>
        /// 缓存
        /// </summary>
        protected static ConcurrentDictionary<string, Baidu.Aip.Face.Face> BIDUClientCache = new ConcurrentDictionary<string, Baidu.Aip.Face.Face>();
        /// <summary>
        /// AOP
        /// </summary>
        protected Baidu.Aip.Face.Face client = null;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="_Req"></param>
        public BusinessBIDU(XAIReqBase _Req)
        {
            if (BIDUClientCache.Where(w => w.Key == _Req.AppCode).Count() == 0)
            {
                lock (BIDUClientCache)
                {
                    using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
                    {
                        var dbApp = dbContext.DbApp(_Req.AppCode);
                        if (dbApp != null)
                        {
                            client = new Baidu.Aip.Face.Face(dbApp.AppKey.ToString(), dbApp.AppSecret.ToString())
                            {
                                Timeout = 60000  // 修改超时时间
                            };
                            BIDUClientCache.AddOrUpdate(_Req.AppCode, client, (key, value) => value);
                        }
                        else
                            throw new Exception("Missing app config or not activated!");
                    }
                }
            }
            else
                client = BIDUClientCache.Where(w => w.Key == _Req.AppCode).FirstOrDefault().Value;
        }
        /// <summary>
        /// 刷脸认证
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResAuth Auth(XAIReqAuth reqData)
        {
            var image_list = new List<BIDUImageInfo>();
            var QualityControl = "QualityControl".ConfigValue();
            var LivenessControl = "LivenessControl".ConfigValue();
            reqData.Images.ForEach(f =>
            {
                var image = new BIDUImageInfo()
                {
                    image = f.Image.Split(new string[] { ";base64," }, StringSplitOptions.RemoveEmptyEntries)[1],
                    image_type = "BASE64",
                    face_type = f.Kind == "1" ? "LIVE" : f.Kind == "2" ? "IDCARD" : f.Kind,
                    quality_control = QualityControl.IsNullOrEmptyOfVar() ? "NORMAL" : QualityControl,
                    liveness_control = (f.Kind == "LIVE" && !LivenessControl.IsNullOrEmptyOfVar()) ? LivenessControl : "NONE"
                };
                image_list.Add(image);
            });
            LogModule.Info("XAI->BIDU:Auth--->入参：" + reqData.ToJson());
            var resJson = client.Match(JArray.Parse(image_list.ToJson())).ToJson();
            LogModule.Info("XAI->BIDU:Auth--->出参：" + resJson);
            var res = resJson.ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(7100, typeof(BIDUErrorCodeEnum).GetEnumName(res.error_code.ToInt()));
            
            if (res.result.score < 80)
                throw new XAIException(7101, "图片对比阈值过低，对比失败！");
            return new XAIResAuth()
            {
                AuthId = res.log_id,
                FaceTokenList = res.result.face_list.Select(s => s.face_token).ToList(),
                PaperWorkNo = reqData.UserInfo.PaperWorkNo,
                PhoneNo = reqData.UserInfo.PhoneNo,
                UserId = reqData.UserId
            };
        }
        /// <summary>
        /// 刷脸识别
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResFind Find(XAIReqFind reqData)
        {
            LogModule.Info("XAI->BIDU:Find--->入参：" + reqData.ToJson());
            var resJson = client.Search(reqData.Image.Split(new string[] { ";base64," }, StringSplitOptions.RemoveEmptyEntries)[1], "BASE64", reqData.GroupId).ToJson();
            LogModule.Info("XAI->BIDU:Find--->出参：" + resJson);
            var res = resJson.ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(7100, typeof(BIDUErrorCodeEnum).GetEnumName(res.error_code.ToInt()));
            res.result.user_list = res.result.user_list.Where(w => w.score > 80).OrderByDescending(o => o.score).ToList();
            if (res.result.user_list.Count() == 0)
                throw new XAIException(7101, "未识别出有效用户");
            return new XAIResFind()
            {
                UserId = res.result.user_list.OrderByDescending(w => w.score).First().user_id
            };
        }
        /// <summary>
        /// 刷脸新增
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResFAdd FAdd(XAIReqFAdd reqData)
        {
            LogModule.Info("XAI->BIDU:FAdd--->入参：" + reqData.ToJson());
            var options = new Dictionary<string, object>() { { "user_info", reqData.UserInfo.ToJson() } };
            var resJson = client.UserAdd(reqData.Image.Split(new string[] { ";base64," }, StringSplitOptions.RemoveEmptyEntries)[1], "BASE64", reqData.GroupId, reqData.UserId, options).ToJson();
            LogModule.Info("XAI->BIDU:FAdd--->出参：" + resJson);
            var res = resJson.ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(7100, typeof(BIDUErrorCodeEnum).GetEnumName(res.error_code.ToInt()));
            return new XAIResFAdd()
            {
                AuthId = res.log_id,
                FaceToken = res.result.face_token,
                LocationLeft = res.result.location.left.ToString(),
                LocationTop = res.result.location.top.ToString(),
                LocationWidth = res.result.location.width.ToString(),
                LocationHeight = res.result.location.height.ToString(),
                LocationRotaion = res.result.location.rotation.ToString()
            };
        }
        /// <summary>
        /// 刷脸更新
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResFMod FMod(XAIReqFMod reqData)
        {
            LogModule.Info("XAI->BIDU:FMod--->入参：" + reqData.ToJson());
            var resJson = client.UserUpdate(reqData.Image.Split(new string[] { ";base64," }, StringSplitOptions.RemoveEmptyEntries)[1], "BASE64", reqData.GroupId, reqData.UserId).ToJson();
            LogModule.Info("XAI->BIDU:FMod--->出参：" + resJson);
            var res = resJson.ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(7100, typeof(BIDUErrorCodeEnum).GetEnumName(res.error_code.ToInt()));
            return new XAIResFMod()
            {
            };
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResFDel FDel(XAIReqFDel reqData)
        {
            LogModule.Info("XAI->BIDU:FDel--->入参：" + reqData.ToJson());
            var resJson = client.UserDelete(reqData.GroupId, reqData.UserId).ToJson();
            LogModule.Info("XAI->BIDU:FDel--->出参：" + resJson);
            var res = resJson.ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(7100, typeof(BIDUErrorCodeEnum).GetEnumName(res.error_code.ToInt()));
            return new XAIResFDel()
            {
            };
        }
        /// <summary>
        /// 用户查询
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResFGet FGet(XAIReqFGet reqData)
        {
            LogModule.Info("XAI->BIDU:FGet--->入参：" + reqData.ToJson());
            var resJson = client.UserGet(reqData.UserId, reqData.GroupId).ToJson();
            LogModule.Info("XAI->BIDU:FGet--->出参：" + resJson);
            var res = resJson.ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(7100, typeof(BIDUErrorCodeEnum).GetEnumName(res.error_code.ToInt()));
            return new XAIResFGet()
            {
                UserInfo = res.result.user_list.FirstOrDefault()?.user_info.ToEntity<BCL.ToolLibWithApp.XAI.Entity.UserInfo>()
            };
        }
        /// <summary>
        /// 新增用户组
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResAddGroup AddGroup(XAIReqAddGroup reqData)
        {
            LogModule.Info("XAI->BIDU:AddGroup--->入参：" + reqData.ToJson());
            var resJson = client.GroupAdd(reqData.GroupId).ToJson();
            LogModule.Info("XAI->BIDU:AddGroup--->出参：" + resJson);
            var res = resJson.ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(7100, typeof(BIDUErrorCodeEnum).GetEnumName(res.error_code.ToInt()));
            return new XAIResAddGroup()
            {
            };
        }
        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResDeleteGroup DeleteGroup(XAIReqDeleteGroup reqData)
        {
            LogModule.Info("XAI->BIDU:DeleteGroup--->入参：" + reqData.ToJson());
            var resJson = client.GroupDelete(reqData.GroupId).ToJson();
            LogModule.Info("XAI->BIDU:DeleteGroup--->出参：" + resJson);
            var res = resJson.ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(7100, typeof(BIDUErrorCodeEnum).GetEnumName(res.error_code.ToInt()));
            return new XAIResDeleteGroup()
            {
            };
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResGetUserList GetUserList(XAIReqGetUserList reqData)
        {
            LogModule.Info("XAI->BIDU:GetUserList--->入参：" + reqData.ToJson());
            var resJson = client.GroupGetusers(reqData.GroupId).ToJson();
            LogModule.Info("XAI->BIDU:GetUserList--->出参：" + resJson);
            var res = resJson.ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(7100, typeof(BIDUErrorCodeEnum).GetEnumName(res.error_code.ToInt()));
            return new XAIResGetUserList()
            {
                UserIdList = res.result.user_id_list
            };
        }
        /// <summary>
        /// 删除人脸
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResDeleteFace DeleteFace(XAIReqDeleteFace reqData)
        {
            LogModule.Info("XAI->BIDU:DeleteFace--->入参：" + reqData.ToJson());
            var resJson = client.FaceDelete(reqData.GroupId, reqData.UserId, reqData.FaceToken).ToJson();
            LogModule.Info("XAI->BIDU:DeleteFace--->出参：" + resJson);
            var res = resJson.ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(7100, typeof(BIDUErrorCodeEnum).GetEnumName(res.error_code.ToInt()));
            return new XAIResDeleteFace()
            {
            };

        }
    }
}
