using BCL.DataAccess;
using BCL.DataAccess.DbEntity.XAI;
using BCL.ToolLib;
using BCL.ToolLib.Enums;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.UPP;
using BCL.ToolLibWithApp.XAI;
using BCL.ToolLibWithApp.XAI.Entity;
using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using System;
using System.Collections.Concurrent;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public XAIModule(string rootPath)
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
                    var groupId = "G_" + _App.AppCode + "_01";
                    biz.UserId = groupId + "_" + biz.UserInfo.PaperWorkNo;
                    #region 参数判断
                    if (biz.Images.Count() != 2 || biz.Images.Where(w => w.Kind == "LIVE" || w.Kind == "1").Count() == 0 || biz.Images.Where(w => w.Kind == "IDCARD" || w.Kind == "2").Count() == 0)
                        throw new ArgumentNullException("Images对比图片必须为两张，且一张为生活照，一张为证件照");
                    biz.Images.ForEach(f =>
                    {
                        if (!f.Image.Replace("\r\n", "").IsBase64())
                            throw new ArgumentNullException("Images必须是BASE64编码");
                        if (!Regex.IsMatch(f.Image, @"^data:image/.{3,5};base64,"))
                            throw new ArgumentNullException("Images必须包含头如【data:image/.jpg;base64, 】的BASE64编码");
                        f.Kind.IsNullOrEmptyOfVar("Kind");
                    });
                    if (biz.UserInfo == null)
                        throw new ArgumentNullException("UserInfo用户信息不可为空！");
                    biz.UserInfo.PaperWorkNo.IsNullOrEmptyOfVar("UserInfo.PaperWorkNo");
                    #endregion
                    using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
                    {
                        var patientList = dbContext.Set<Db_Patient>().Where(w => w.PaperworkNo == biz.UserInfo.PaperWorkNo && w.IsDetele == 0).AsNoTracking().FirstOrDefault();
                        if (patientList != null)
                            return ResCode.业务错误.XAIAckOfErr("该用户已认证，请勿重复认证!");
                        var authlog = dbContext.Set<Db_AuthLog>().Where(w => w.Id == _Req.RowId).FirstOrDefault();
                        if (authlog == null)
                            return ResCode.业务错误.XAIAckOfErr("not found authlog,id=" + _Req.RowId);
                        //人脸对比
                        var resAuth = _Business.Auth(biz);

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
                        try
                        {
                            var IDCARDImage = biz.Images.Where(w => w.Kind == "IDCARD" || w.Kind == "2").FirstOrDefault();
                            //循环图片插入图片和人脸表
                            var dbImage = new Db_Image() { ImageId = Snowflake.Instance().GetId().ToString(), Image = IDCARDImage.Image };
                            dbContext.Entry(dbImage).State = EntityState.Added;
                            var reqFAdd = new XAIReqFAdd()
                            {
                                UserId = biz.UserId,
                                UserInfo = biz.UserInfo,
                                Image = IDCARDImage.Image,
                                GroupId = groupId
                            };
                            //人脸新增
                            var resFAdd = _Business.FAdd(reqFAdd);
                            var dbface = new Db_Face()
                            {
                                AuthId = resFAdd.AuthId,
                                AppCode = _App.AppCode,
                                ImageId = dbImage.ImageId,
                                //暂写死BASE64
                                ImageType = "BASE64",
                                FaceType = IDCARDImage.Kind,
                                FaceToken = resFAdd.FaceToken,
                                GroupId = groupId,
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
                            resAuth.UserInfo = biz.UserInfo;
                            resAuth.UserInfo.PhoneNo = biz.UserInfo.PhoneNo.IsNullOrEmptyOfVar() ? "" : biz.UserInfo.PhoneNo;
                            var res = ResCode.交易成功.XAIAckOfBiz(resAuth);
                            //补充authlog
                            res.ModAuthLog(_Req.RowId, biz.Images, resAuth.AuthId);
                            dbContext.SaveChanges();
                            return res;
                        }
                        catch (Exception ex)
                        {

                            var reqFDel = new XAIReqFDel() { GroupId = groupId, UserId = biz.UserId };
                            //删除用户
                            var resFAdd = _Business.FDel(reqFDel);
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfErr(ex.Message);
                }
            };
            Post["/Find"] = o =>
            {
                try
                {
                    _Req.AddFindLog();
                    var biz = _Req.Args.ToEntity<XAIReqFind>();
                    biz.HospitalId = biz.HospitalId.IsNullOrEmptySetVar("0000");
                    #region 参数判断
                    var xxx = this.Request.Body;
                    if (!biz.Image.Replace("\r\n", "").IsBase64())
                        throw new ArgumentNullException("Image必须是BASE64编码");
                    if (!Regex.IsMatch(biz.Image, @"^^data:image/.{3,5};base64,"))
                        throw new ArgumentNullException("Image必须包含头如【data:image/.jpg;base64, 】的BASE64编码");
                    #endregion
                    var groupId = "G_" + _App.AppCode + "_01";
                    using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
                    {
                        var dbImage = new Db_Image() { ImageId = Snowflake.Instance().GetId().ToString(), Image = biz.Image };
                        dbContext.Entry(dbImage).State = EntityState.Added;
                        dbContext.SaveChanges();
                        biz.GroupId = groupId;
                        var resFind = _Business.Find(biz);
                        var dbPatient = dbContext.Set<Db_Patient>().Where(w => w.UserId == resFind.UserId && w.IsDetele == 0).AsNoTracking().FirstOrDefault();
                        if (dbPatient == null)
                            return ResCode.业务错误.XAIAckOfErr("未查找到用户：" + resFind.UserId);
                        resFind.UserInfo = new UserInfo
                        {
                            PhoneNo = dbPatient.PhoneNo.IsNullOrEmptyOfVar() ? "" : dbPatient.PhoneNo,
                            PaperWorkNo = dbPatient.PaperworkNo,
                            Name = dbPatient.Name,
                            Sex = dbPatient.Sex,
                            Nature = dbPatient.Natrue,
                            Address = dbPatient.Adress,
                            Birthday = dbPatient.Birthday
                        };
                        var dbUserIndexList = dbContext.Set<Db_UserIndex>().Where(w => w.HospitalId == biz.HospitalId && w.UserId == resFind.UserId && w.IsDelete == 0).ToList();
                        resFind.Indexs = dbUserIndexList.Select(s => new UserIndexInfo { Index = s.Index, IndexType = s.IndexType }).ToList();
                        var res = ResCode.交易成功.XAIAckOfBiz(resFind);
                        //补充identlog
                        res.ModFindLog(_Req.RowId, dbImage);
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    if (ex.HResult == 7101)
                        return ResCode.刷脸业务错误.XAIAckOfErr(ex.Message);
                    return ResCode.业务错误.XAIAckOfErr(ex.Message);
                }
            };
            Post["/FAdd"] = o =>
            {
                try
                {
                    var biz = _Req.Args.ToEntity<XAIReqFAdd>();
                    #region 参数判断
                    if (!biz.Image.Replace("\r\n", "").IsBase64())
                        throw new ArgumentNullException("Image必须是BASE64编码");
                    if (!Regex.IsMatch(biz.Image, @"^^data:image/.{3,5};base64,"))
                        throw new ArgumentNullException("Image必须包含头如【data:image/.jpg;base64, 】的BASE64编码");
                    if (biz.UserInfo == null)
                        throw new ArgumentNullException("UserInfo用户信息不可为空！");
                    biz.UserInfo.PhoneNo.IsNullOrEmptyOfVar("UserInfo.PhoneNo");
                    biz.UserInfo.PaperWorkNo.IsNullOrEmptyOfVar("UserInfo.PaperWorkNo");
                    #endregion
                    biz.GroupId = "G_" + _App.AppCode + "_01";
                    biz.UserId = biz.GroupId + "_" + biz.UserInfo.PaperWorkNo;
                    //插入成功标志
                    var FaceToken = "";
                    using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
                    {
                        var dbPatient = dbContext.Set<Db_Patient>().Where(w => w.UserId == biz.UserId && w.IsDetele == 0).AsNoTracking().FirstOrDefault();
                        var IsDeleteUser = (dbPatient != null && dbPatient.IsDetele == 0) ? false : true;
                        var dbImage = new Db_Image() { ImageId = Snowflake.Instance().GetId().ToString(), Image = biz.Image };
                        dbContext.Entry(dbImage).State = EntityState.Added;
                        try
                        {
                            var resFAdd = _Business.FAdd(biz);
                            FaceToken = resFAdd.FaceToken;
                            if (dbPatient == null)
                            {
                                //插一条人员表
                                var newDbPatient = new Db_Patient()
                                {
                                    AuthId = resFAdd.AuthId,
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
                                dbContext.Entry(newDbPatient).State = EntityState.Added;
                            }
                            else if (dbPatient != null && dbPatient.IsDetele != 0)
                            {
                                //更新人员表
                                dbPatient = new Db_Patient()
                                {
                                    AuthId = resFAdd.AuthId,
                                    UserId = biz.UserId,
                                    Empi = null,
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
                                dbContext.Entry(dbPatient).State = EntityState.Modified;
                            }
                            //插入人脸表
                            var dbface = new Db_Face()
                            {
                                AuthId = resFAdd.AuthId,
                                AppCode = _App.AppCode,
                                ImageId = dbImage.ImageId,
                                ImageType = "BASE64",
                                FaceType = "LIVE",
                                FaceToken = resFAdd.FaceToken,
                                GroupId = biz.GroupId,
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
                            dbContext.SaveChanges();
                            return ResCode.交易成功.XAIAckOfBiz(new XAIResFAdd() { UserId = biz.UserId });
                        }
                        catch (Exception ex)
                        {
                            if (IsDeleteUser)
                            {
                                var reqFDel = new XAIReqFDel() { GroupId = biz.GroupId, UserId = biz.UserId };
                                //删除用户
                                var resFAdd = _Business.FDel(reqFDel);
                            }
                            else
                            {
                                if (!FaceToken.IsNullOrEmptyOfVar())
                                {
                                    var reqDeleteFace = new XAIReqDeleteFace() { GroupId = biz.GroupId, UserId = biz.UserId, FaceToken = FaceToken };
                                    //删除用户
                                    var resDeleteFace = _Business.DeleteFace(reqDeleteFace);
                                }
                            }
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfErr(ex.Message);
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
                            return ResCode.业务错误.XAIAckOfErr("未查询到用户：" + biz.UserId);
                        var dbface = dbContext.Set<Db_Face>().Where(w => w.UserId == biz.UserId && w.FaceType == "LIVE" && w.IsDelete == 0).FirstOrDefault();
                        if (dbface == null)
                            return ResCode.业务错误.XAIAckOfErr("未查询到用户的人脸库：" + biz.UserId);
                        biz.GroupId = dbface.GroupId;
                        if (!biz.Image.IsNullOrEmptyOfVar())
                        {
                            if (!biz.Image.Replace("\r\n", "").IsBase64())
                                throw new ArgumentNullException("Image必须是BASE64编码");
                            if (!Regex.IsMatch(biz.Image, @"^^data:image/.{3,5};base64,"))
                                throw new ArgumentNullException("Image必须包含头如【data:image/.jpg;base64, 】的BASE64编码");
                            var dbImage = new Db_Image() { ImageId = Snowflake.Instance().GetId().ToString(), Image = biz.Image };
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
                    return ResCode.交易成功.XAIAckOfBiz(new XAIResFMod());
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfErr(ex.Message);
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
                    using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
                    {
                        var dbPatient = dbContext.Set<Db_Patient>().Where(w => w.UserId == biz.UserId && w.IsDetele == 0).FirstOrDefault();
                        if (dbPatient == null)
                            return ResCode.业务错误.XAIAckOfErr("未查询到用户：" + biz.UserId);
                        var reqFDel = new XAIReqFDel()
                        {
                            GroupId = "G_" + _App.AppCode + "_01",
                            UserId = biz.UserId
                        };
                        var resFDel = _Business.FDel(reqFDel);
                        dbPatient.IsDetele = 1;
                        var dbFaceList = dbContext.Set<Db_Face>().Where(w => w.UserId == biz.UserId).ToList();
                        dbFaceList.ForEach(f => { f.IsDelete = 1; });
                        dbContext.SaveChanges();
                        return ResCode.交易成功.XAIAckOfBiz(new XAIResFDel());
                    }
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfErr(ex.Message);
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
                    using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
                    {
                        var dbPatient = dbContext.Set<Db_Patient>().Where(w => w.UserId == biz.UserId && w.IsDetele == 0).FirstOrDefault();
                        if (dbPatient == null)
                            return ResCode.业务错误.XAIAckOfErr("未查询到用户：" + biz.UserId);
                        var dbFaceList = dbContext.Set<Db_Face>().Where(w => w.UserId == biz.UserId && w.IsDelete == 0).ToList();
                        var dbUserIndexList = dbContext.Set<Db_UserIndex>().Where(w => w.UserId == biz.UserId && w.IsDelete == 0).ToList();
                        var res = new XAIResFGet()
                        {
                            UserInfo = new UserInfo
                            {
                                PhoneNo = dbPatient.PhoneNo,
                                PaperWorkNo = dbPatient.PaperworkNo,
                                Name = dbPatient.Name,
                                Sex = dbPatient.Sex,
                                Nature = dbPatient.Natrue,
                                Address = dbPatient.Adress,
                                Birthday = dbPatient.Birthday,
                            },
                            Images = dbFaceList.Select(s => new ImageInfo { ImageId = s.ImageId, Kind = s.FaceType }).ToList(),
                            Indexs = dbUserIndexList.Select(s => new UserIndexInfo { Index = s.Index, IndexType = s.IndexType }).ToList()
                        };
                        //var resGet = _Business.FGet(biz);
                        return ResCode.交易成功.XAIAckOfBiz(res);
                    }
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfErr(ex.Message);
                }
            };
            Post["/IAdd"] = o =>
            {
                try
                {
                    var biz = _Req.Args.ToEntity<XAIReqIAdd>();
                    biz.HospitalId = biz.HospitalId.IsNullOrEmptySetVar("0000");
                    #region 参数判断
                    biz.UserId.IsNullOrEmptyOfVar("UserId");
                    if (biz.Indexs == null)
                        throw new ArgumentNullException("Indexs用户索引信息不可为空！");
                    biz.Indexs.ForEach(f =>
                    {
                        f.Index.IsNullOrEmptyOfVar("Index");
                        f.IndexType.IsNullOrEmptyOfVar("IndexType");
                    });
                    #endregion
                    using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
                    {
                        var dbIndexList = dbContext.Set<Db_UserIndex>().Where(w => w.HospitalId == biz.HospitalId && w.UserId == biz.UserId).ToList();
                        var IndexCount = "IndexCount".ConfigValue("2").ToInt();
                        if (biz.Indexs.Count() > IndexCount || (dbIndexList.Count() + biz.Indexs.Count()) > IndexCount)
                        {
                            throw new XAIException("无法添加，用户索引添加索引超过最大限：" + IndexCount.ToString());
                        }
                        biz.Indexs.ForEach(f =>
                        {
                            var dbIndex = dbIndexList.Where(w => w.IndexType == f.IndexType).FirstOrDefault();
                            if (dbIndex != null)
                            {
                                if (dbIndex.IsDelete == 0 && dbIndex.Index == f.Index)
                                    throw new XAIException("用户索引已存在，请勿重复添加：" + f.Index);
                                dbIndex.IsDelete = 0;
                                dbIndex.ModDate = DateTime.Now;
                                dbIndex.ModUser = "XAI";
                            }
                            else
                            {
                                dbIndex = new Db_UserIndex()
                                {
                                    HospitalId = biz.HospitalId,
                                    UserId = biz.UserId,
                                    Index = f.Index,
                                    IndexType = f.IndexType,
                                    IsDelete = 0,
                                    AddDate = DateTime.Now,
                                };
                                dbContext.Entry(dbIndex).State = EntityState.Added;
                            }
                        });
                        dbContext.SaveChanges();
                        return ResCode.交易成功.XAIAckOfBiz(new XAIResIAdd());
                    }
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfErr(ex.Message);
                }
            };
            Post["/IDel"] = o =>
                {
                    try
                    {
                        var biz = _Req.Args.ToEntity<XAIReqIDel>();
                        biz.HospitalId = biz.HospitalId.IsNullOrEmptySetVar("0000");
                        #region 参数判断
                        biz.UserId.IsNullOrEmptyOfVar("UserId");
                        if (biz.Indexs == null)
                            throw new ArgumentNullException("Indexs用户索引信息不可为空！");
                        biz.Indexs.ForEach(f =>
                                {
                                    f.Index.IsNullOrEmptyOfVar("Index");
                                    f.IndexType.IsNullOrEmptyOfVar("IndexType");
                                });
                        #endregion
                        using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
                        {
                            var dbIndexList = dbContext.Set<Db_UserIndex>().Where(w => w.HospitalId == biz.HospitalId && w.UserId == biz.UserId).ToList();
                            biz.Indexs.ForEach(f =>
                                            {
                                                var dbIndex = dbContext.Set<Db_UserIndex>().Where(w => w.Index == f.Index && w.IndexType == f.IndexType).FirstOrDefault();
                                                if (dbIndex == null)
                                                    throw new XAIException("未查询到用户索引：" + f.Index);
                                                dbIndex.IsDelete = 1;
                                                dbIndex.ModDate = DateTime.Now;
                                                dbIndex.ModUser = "XAI";
                                            });
                            dbContext.SaveChanges();
                            return ResCode.交易成功.XAIAckOfBiz(new XAIResIDel());
                        }
                    }
                    catch (Exception ex)
                    {
                        LogModule.Info(ex);
                        return ResCode.业务错误.XAIAckOfErr(ex.Message);
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
            if (this.Request.Headers.ContentType == "application/json" || this.Request.Headers.ContentType == "application/json;")
            {
                var body = this.Request.Body.AsString();
                LogModule.Info("XAI->Req--->入参:" + body);
                //支持Json传输 Args传对象
                try
                {
                    var _ReqJson = body.ToEntity<XAIReqBaseJson>();
                    _Req = new XAIReqBase()
                    {
                        AppCode = _ReqJson.AppCode,
                        Channel = _ReqJson.Channel,
                        Args = _ReqJson.Args.ToJson(),
                        Kind = _ReqJson.Kind,
                        ReqTime = _ReqJson.ReqTime,
                        TermCode = _ReqJson.TermCode,
                    };
                }
                catch
                {
                    _Req = body.ToEntity<XAIReqBase>();
                }
            }
            else
            {
                _Req = this.Bind<XAIReqBase>();
                LogModule.Info("XAI->Req--->入参:" + _Req.ToJson());
            }
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
                            LogModule.Info("XAI->Res--->出参:" + resMsg);
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
