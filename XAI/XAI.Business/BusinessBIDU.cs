using BCL.DataAccess;
using BCL.ToolLib;
using BCL.ToolLibWithApp.XAI;
using BCL.ToolLibWithApp.XAI.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                            var client = new Baidu.Aip.Face.Face(dbApp.AppKey.ToString(), dbApp.AppSecret.ToString())
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
            reqData.Images.ForEach(f =>
            {
                var image = new BIDUImageInfo()
                {
                    image = f.Image,
                    image_type = "BASE64",
                    face_type = f.Kind,
                    quality_control = "NONE",
                    liveness_control = f.Kind == "LIVE" ? "NORMAL" : "NONE"
                };
                image_list.Add(image);
            });
            var res = client.Match(JArray.Parse(image_list.ToJson())).ToJson().ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(3100, res.error_msg);
            if (res.score < 80)
                throw new XAIException(3100, "图片对比阈值过低，对比失败！");
            return new XAIResAuth()
            {
                AuthId = res.log_id,
                FaceTokenList = res.face_list.Select(s => s.face_token).ToList(),
                PaperWorkNo = reqData.UserInfo.PaperWorkNo,
                PhoneNo = reqData.UserInfo.PhoneNo,
                UserId = reqData.UserId
            };
            //Todo 业务逻辑
        }
        /// <summary>
        /// 刷脸识别
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResFind Find(XAIReqFind reqData)
        {
            var res = client.Search(reqData.Image, "BASE64", reqData.GroupId).ToJson().ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(3100, res.error_msg);
            if (res.user_list.Count() == 0)
                throw new XAIException(3100, "未识别出有效用户");
            return new XAIResFind()
            {
                UserId = res.user_list.OrderByDescending(w => w.score).First().user_id
            };
        }
        /// <summary>
        /// 刷脸新增
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResFAdd FAdd(XAIReqFAdd reqData)
        {
            var res = client.UserAdd(reqData.Image, "BASE64", reqData.GroupId, reqData.UserId).ToJson().ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(3100, res.error_msg);
            return new XAIResFAdd()
            {
                FaceToken = res.face_token,
                LocationLeft = res.location.left.ToString(),
                LocationTop = res.location.top.ToString(),
                LocationWidth = res.location.width.ToString(),
                LocationHeight = res.location.height.ToString(),
                LocationRotaion = res.location.rotation.ToString()
            };
        }
        /// <summary>
        /// 刷脸更新
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResFMod FMod(XAIReqFMod reqData)
        {
            //Todo 业务逻辑
            throw new NotImplementedException();
        }
        /// <summary>
        /// 刷脸删除
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResFDel FDel(XAIReqFDel reqData)
        {
            //Todo 业务逻辑
            throw new NotImplementedException();
        }
        /// <summary>
        /// 用户查询
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResFGet FGet(XAIReqFGet reqData)
        {
            //Todo 业务逻辑
            throw new NotImplementedException();
        }
        /// <summary>
        /// 新增用户组
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        public XAIResAddGroup AddGroup(XAIReqAddGroup reqData)
        {
            var res = client.GroupAdd(reqData.GroupId).ToJson().ToEntity<BIDUResponse>();
            if (res.error_code != 0)
                throw new XAIException(3100, res.error_msg);
            return new XAIResAddGroup()
            {
            };
        }
    }
}
