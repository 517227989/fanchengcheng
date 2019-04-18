using BCL.DataAccess;
using BCL.DataAccess.DbEntity.XAI;
using BCL.ToolLib;
using BCL.ToolLib.Enums;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.UPP;
using BCL.ToolLibWithApp.XAI;
using BCL.ToolLibWithApp.XAI.Entity;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Concurrent;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using XAI.Business;

namespace XAI.Provider.Modules
{
    public class XAIModule : NancyModule
    {
        /// <summary>
        /// 
        /// </summary>
        protected static ConcurrentDictionary<string, Db_FApp> _AppCache = new ConcurrentDictionary<string, Db_FApp>();
        /// <summary>
        /// 
        /// </summary>
        protected XAIReqBase _Req { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected Db_FApp _App { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected IBusiness _Business { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootPath"></param>
        public UPPModule(string rootPath)
            : base(rootPath)
        {

        }
        public XAIModule()
            : base("/API")
        {
            Init();

            Before += RequestFilter;

            After += ResponseFilter;

            //PDF文档
            Get["/"] = o =>
            {
                return Response.AsFile("XAI_交互协议.pdf");
            };
            Post["/Auth"] = o =>
            {
                try
                {
                    _Req.AddAuthLog();
                    var biz = _Req.Args.ToEntity<XAIReqAuth>();
                    #region 参数判断
                    if (biz.Images.Count() != 2)
                        throw new ArgumentNullException("Images对比图片必须为两张！");
                    biz.Images.ForEach(f =>
                    {
                        f.Image.IsNullOrEmptyOfVar("Image");
                        f.Kind.IsNullOrEmptyOfVar("Kind");
                    });
                    if (biz.UserInfo == null)
                        throw new ArgumentNullException("UserInfo用户信息不可为空！");
                    biz.UserInfo.PhoneNo.IsNullOrEmptyOfVar("UserInfo.PhoneNo");
                    biz.UserInfo.PaperWorkNo.IsNullOrEmptyOfVar("UserInfo.PaperWorkNo");
                    #endregion
                    using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
                    {
                        var patient = dbContext.Set<Db_Patient>().Where(w => w.PaperworkNo == biz.UserInfo.PaperWorkNo && w.IsDetele == 0).AsNoTracking().FirstOrDefault();
                        if (patient != null)
                            return ResCode.业务错误.XAIAckOfBiz("该用户已认证，请勿重复认证!").ToJson();
                        var authlog = dbContext.Set<Db_AuthLog>().Where(w => w.Id == _Req.RowId).FirstOrDefault();
                        if (authlog == null)
                            return ResCode.业务错误.XAIAckOfBiz("not found authlog,id=" + _Req.RowId).ToJson();
                        //人脸对比
                        var resAuth = _Business.Auth(biz);
                        biz.UserId = "Face_" + biz.UserInfo.PaperWorkNo + DateTime.Now;
                        //插一条人员表
                        var dbPatient = new Db_Patient()
                        {
                            AuthId = resAuth.AuthId,
                            UserId = biz.UserId,
                            Name = biz.UserInfo.Name,
                            PhoneNo = biz.UserInfo.PhoneNo,
                            Sex = biz.UserInfo.Sex,
                            Natrue = biz.UserInfo.Nature,
                            Adress = biz.UserInfo.Address,
                            Birthday = biz.UserInfo.Birthday,
                            PaperworkType = "IDCARD",
                            PaperworkNo = biz.UserInfo.PaperWorkNo,
                            IsDetele = 0,
                            AddDate = DateTime.Now
                        };
                        dbContext.Entry(dbPatient).State = EntityState.Added;
                        //循环图片插入图片和人脸表
                        biz.Images.ForEach(f =>
                        {
                            var dbImage = new Db_Image() { ImageId = "Ig".CreateKey(), Image = f.Image };
                            f.ImageId = dbImage.ImageId;
                            dbContext.Entry(dbImage).State = EntityState.Added;
                            var reqFAdd = new XAIReqFAdd()
                            {
                                UserId = biz.UserId,
                                UserInfo = biz.UserInfo,
                                Image = dbImage.ImageId,
                                GroupId = "Group_" + _App.AppCode + "_01"
                            };
                            //人脸新增
                            var resFAdd = _Business.FAdd(reqFAdd);
                            var dbface = new Db_Face()
                            {
                                AuthId = resAuth.AuthId,
                                AppCode = _App.AppCode,
                                ImageId = dbImage.ImageId,
                                //暂写死BASE64
                                ImageType = "BASE64",
                                FaceType = f.Kind,
                                FaceToken = resFAdd.FaceToken,
                                GroupId = "Group_" + _App.AppCode + "_01",
                                UserId = biz.UserId,
                                UserInfo = biz.UserInfo.ToJson(),
                                LocationLeft = resFAdd.LocationLeft,
                                LocationTop = resFAdd.LocationTop,
                                LocationHeight = resFAdd.LocationHeight,
                                LocationWidth = resFAdd.LocationWidth,
                                LocationRotaion = resFAdd.LocationRotaion,
                                IsDelete = 0,
                                AddDate = DateTime.Now,
                            };
                            dbContext.Entry(dbface).State = EntityState.Added;
                        });
                        var res = ResCode.交易成功.XAIAckOfBiz(resAuth).ToJson();
                        //补充authlog
                        res.ModAuthLog(_Req.RowId, biz.Images, resAuth.AuthId);
                        dbContext.SaveChanges();
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfBiz(ex.Message).ToJson();
                }
            };
            Post["/Find"] = o =>
            {
                try
                {
                    _Req.AddFindLog();
                    var biz = _Req.Args.ToEntity<XAIReqFind>();
                    #region 参数判断
                    biz.Image.IsNullOrEmptyOfVar("Image");
                    #endregion

                    using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
                    {
                        var dbImage = new Db_Image() { ImageId = "Ig".CreateKey(), Image = biz.Image };
                        dbContext.Entry(dbImage).State = EntityState.Added;
                        dbContext.SaveChanges();
                        var resFind = _Business.Find(biz);
                        var dbPatient = dbContext.Set<Db_Patient>().Where(w => w.UserId == resFind.UserId && w.IsDetele == 0).AsNoTracking().FirstOrDefault();
                        if (dbPatient == null)
                            return ResCode.业务错误.XAIAckOfBiz("未查找到用户：" + resFind.UserId).ToJson();
                        resFind.EmpId = dbPatient.PaperworkNo;
                        var res = ResCode.交易成功.XAIAckOfBiz(resFind).ToJson();
                        //补充identlog
                        res.ModFindLog(_Req.RowId, dbImage);
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfBiz(ex.Message).ToJson();
                }
            };
            Post["/FAdd"] = o =>
            {
                try
                {
                    var biz = _Req.Args.ToEntity<XAIReqFAdd>();
                    #region 参数判断
                    biz.UserId.IsNullOrEmptyOfVar("UserId");
                    biz.Image.IsNullOrEmptyOfVar("Image");
                    if (biz.UserInfo == null)
                        throw new ArgumentNullException("UserInfo用户信息不可为空！");
                    biz.UserInfo.PhoneNo.IsNullOrEmptyOfVar("UserInfo.PhoneNo");
                    biz.UserInfo.PaperWorkNo.IsNullOrEmptyOfVar("UserInfo.PaperWorkNo");
                    #endregion
                    //Todo 业务逻辑
                    return ResCode.交易成功.XAIAckOfBiz(new XAIResFAdd() { UserId = biz.UserId }).ToJson();
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfBiz(ex.Message).ToJson();
                }
            };
            Post["/FMod"] = o =>
            {
                try
                {
                    var biz = _Req.Args.ToEntity<XAIReqFMod>();
                    #region 参数判断
                    biz.UserId.IsNullOrEmptyOfVar("UserId");
                    #endregion
                    using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
                    {
                        var dbPatient = dbContext.Set<Db_Patient>().Where(w => w.UserId == biz.UserId && w.IsDetele == 0).FirstOrDefault();
                        if (dbPatient == null)
                            return ResCode.业务错误.XAIAckOfBiz("未查询到用户：" + biz.UserId).ToJson();
                        var dbface = dbContext.Set<Db_Face>().Where(w => w.UserId == biz.UserId && w.FaceType == "LIVE" && w.IsDelete == 0).FirstOrDefault();
                        if (dbface == null)
                            return ResCode.业务错误.XAIAckOfBiz("未查询到用户的人脸库：" + biz.UserId).ToJson();
                        biz.GroupId = dbface.GroupId;
                        if (!biz.Image.IsNullOrEmptyOfVar())
                        {
                            var dbImage = new Db_Image() { ImageId = "Ig".CreateKey(), Image = biz.Image };
                            dbContext.Entry(dbImage).State = EntityState.Added;
                            var resFMod = _Business.FMod(biz);
                            dbface.ImageId = dbImage.ImageId;
                            dbface.LocationLeft = resFMod.LocationLeft;
                            dbface.LocationTop = resFMod.LocationTop;
                            dbface.LocationHeight = resFMod.LocationHeight;
                            dbface.LocationWidth = resFMod.LocationWidth;
                            dbface.LocationRotaion = resFMod.LocationRotaion;
                            dbface.ModDate = DateTime.Now;
                            dbface.ModUser = "XAI";
                        }
                        if (biz.UserInfo != null)
                        {
                            if (!biz.UserInfo.Index.IsNullOrEmptyOfVar())
                                dbPatient.Empi = biz.UserInfo.Index;
                            if (!biz.UserInfo.PhoneNo.IsNullOrEmptyOfVar())
                                dbPatient.PhoneNo = biz.UserInfo.PhoneNo;
                            if (!biz.UserInfo.PaperWorkNo.IsNullOrEmptyOfVar())
                                dbPatient.PaperworkNo = biz.UserInfo.PaperWorkNo;
                            if (!biz.UserInfo.Name.IsNullOrEmptyOfVar())
                                dbPatient.Name = biz.UserInfo.Name;
                            if (!biz.UserInfo.Nature.IsNullOrEmptyOfVar())
                                dbPatient.Natrue = biz.UserInfo.Nature;
                            if (!biz.UserInfo.Address.IsNullOrEmptyOfVar())
                                dbPatient.Adress = biz.UserInfo.Address;
                            if (!biz.UserInfo.Birthday.IsNullOrEmptyOfVar())
                                dbPatient.Birthday = biz.UserInfo.Birthday;
                        }
                        dbContext.SaveChanges();
                    }
                    return ResCode.交易成功.XAIAckOfBiz(new XAIResFMod()).ToJson();
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfBiz(ex.Message).ToJson();
                }
            };
            Post["/FDel"] = o =>
            {
                try
                {
                    var biz = _Req.Args.ToEntity<XAIReqFDel>();
                    #region 参数判断
                    biz.UserId.IsNullOrEmptyOfVar("UserId");
                    #endregion
                    //Todo 业务逻辑
                    return ResCode.交易成功.XAIAckOfBiz(new XAIResFDel()).ToJson();
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfBiz(ex.Message).ToJson();
                }
            };
            Post["/FGet"] = o =>
            {
                try
                {
                    var biz = _Req.Args.ToEntity<XAIReqFGet>();
                    #region 参数判断
                    biz.UserId.IsNullOrEmptyOfVar("UserId");
                    #endregion
                    //Todo 业务逻辑
                    return ResCode.交易成功.XAIAckOfBiz(new XAIResFGet()).ToJson();
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfBiz(ex.Message).ToJson();
                }
            };
        }
        /// <summary>
        /// 初始化
        /// </summary>
        protected static void Init()
        {
            try
            {
                if (_AppCache == null || _AppCache.Count == 0)
                    _AppCache.DbAppConfig();
            }
            catch (Exception ex)
            {
                LogModule.Error(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected virtual Response RequestFilter(NancyContext o)
        {
            InvalidAppCode();

            _Business = new BusinessContainer(null, _Req)._Business as IBusiness;

            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        protected void InvalidAppCode()
        {
            _Req = this.Bind<XAIReqBase>();
            LogModule.Info("XAI->Req--->入参:" + _Req.ToJson());

            if (_Req.AppCode.IsNullOrEmptyOfVar())
                _Req.AppCode = "0000";
            else
                _App = _AppCache.Where(w => w.Key == _Req.AppCode).FirstOrDefault().Value;
            if (_App == null)
                throw new Exception("Invalid AppCode!");

            _Req.ReqTime.IsDateTime("ReqTime");
            _Req.Channel.IsNullOrEmptyOfVar("Channel");
            _Req.Args.IsNullOrEmptyOfVar("Args");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        protected virtual void ResponseFilter(NancyContext o)
        {
            if (o.Request.Url.Path.ToLower() != "/api" &&
                o.Request.Url.Path.ToLower().Contains("receive") != true &&
                o.Response.StatusCode == HttpStatusCode.OK)
            {
                //增加签名
                var s = new MemoryStream();
                o.Response.Contents.Invoke(s);
                if (s.Length > 0)
                {
                    s.Position = 0;
                    using (var r = new StreamReader(s))
                    {
                        var re = r.ReadToEnd();
                        if (re != null)
                        {
                            var res = re.ToEntity<XAIResBase>();
                            var resMsg = res.ToJson();
                            LogModule.Info("UPP->Res--->出参:" + resMsg);
                            o.Response.Contents = (x) =>
                            {
                                var resBytes = Encoding.UTF8.GetBytes(resMsg);
                                x.Write(resBytes, 0, resBytes.Length);
                            };
                        }
                    }
                }
                o.Response.WithContentType("application/json;charset=UTF-8");
            }
        }
    }
}
