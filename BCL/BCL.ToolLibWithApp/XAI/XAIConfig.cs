using BCL.DataAccess;
using BCL.DataAccess.DbEntity.XAI;
using BCL.ToolLib;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.XAI.Entity;
using Dapper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.XAI
{
    public static class XAIConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="appCode"></param>
        /// <returns></returns>
        public static Db_FApp DbApp(this DbContextEx dbContext, string appCode)
        {
            return dbContext.DbApp("SELECT * " +
                                         "FROM FT_App " +
                                        "WHERE AppCode = @AppCode " +
                                          "AND Active = 0 ",
                                       new { AppCode = appCode }).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dynamicSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static IEnumerable<Db_FApp> DbApp(this DbContextEx dbContext, string dynamicSql, object param = null)
        {
            var dbApp = dbContext.Database.Connection.Query<Db_FApp>(dynamicSql, param);
            if (dbApp == null || dbApp.Count() == 0)
                throw new Exception("未开通或未激活,不具备调用条件!");
            return dbApp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DbAppCache"></param>
        public static void DbAppConfig(this ConcurrentDictionary<string, Db_FApp> _DbAppCache)
        {
            lock (_DbAppCache)
            {
                using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.UPPDb)._DataAccess)
                {
                    dbContext.Database.Connection.Query<Db_FApp>("SELECT * FROM FT_App WHERE Active = 0").ToList().ForEach(o =>
                    {
                        _DbAppCache.AddOrUpdate(o.AppCode, o, (key, value) => value);
                    });
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void AddAuthLog(this XAIReqBase req)
        {
            //TODO AUTH和Find记入参日志
            using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
            {
                try
                {
                    var args = req.Args.ToEntity<XAIReqAuth>();
                    var dbAuthLog = new Db_AuthLog
                    {
                        AuthID = "".CreateKey(),
                        AppCode = req.AppCode,
                        PaperworkType = "IDCARD",
                        PaperworkNo = args.UserInfo.PaperWorkNo,
                        PhoneNo = args.UserInfo.PhoneNo,
                        MessageIn = req.ToJson(),
                        InTime = Convert.ToDateTime(req.ReqTime),
                        AddDate = DateTime.Now,
                        IsDelete = 0
                    };
                    dbContext.Entry(dbAuthLog).State = EntityState.Added;
                    dbContext.SaveChanges();
                    req.RowId = dbAuthLog.Id;
                }
                catch (Exception ex)
                {
                    LogModule.Error("Db Fail:" + ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message) + "\r\n参数:" + req.EntityToKeyValue(false));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Res"></param>
        public static void ModAuthLog(this string _ResJson, int _RowId, List<ImageInfo> _Images, string _AuthId)
        {
            var _Res = _ResJson.ToEntity<XAIResBase>();
            using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
            {
                try
                {
                    var dbAuthLog = dbContext.Set<Db_AuthLog>().Where(w => w.Id == _RowId).ToList().FirstOrDefault();
                    if (dbAuthLog == null)
                        throw new Exception("The authlog that needs to be modified does not exist! id=" + _RowId);
                    dbAuthLog.PaperworkImageId = _Images.Where(w => w.Kind == "IDCARD").First().ImageId;
                    dbAuthLog.PageworkImageType = "BASE64";
                    dbAuthLog.FaceImageId = _Images.Where(w => w.Kind == "LIVE").First().ImageId;
                    dbAuthLog.FaceImageType = "BASE64";
                    dbAuthLog.MessageOut = _Res.ToJson();
                    dbAuthLog.ReturnCode = _Res.Code.ToInt();
                    dbAuthLog.ReturnDesc = _Res.Desc;
                    dbAuthLog.OutTime = DateTime.Now;
                    dbAuthLog.ModDate = DateTime.Now;
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    LogModule.Error("Db Fail:" + ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void AddFindLog(this XAIReqBase req)
        {
            using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
            {
                try
                {
                    var args = req.Args.ToEntity<XAIReqFind>();
                    var dbIdentLog = new Db_IdentLog
                    {
                        TimeIn = Convert.ToDateTime(req.ReqTime),
                        AddDate = DateTime.Now,
                        IsDelete = 0
                    };
                    dbContext.Entry(dbIdentLog).State = EntityState.Added;
                    dbContext.SaveChanges();
                    req.RowId = dbIdentLog.Id;
                }
                catch (Exception ex)
                {
                    LogModule.Error("Db Fail:" + ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message) + "\r\n参数:" + req.EntityToKeyValue(false));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="res"></param>
        public static void ModFindLog(this string _ResJson, int _RowId, Db_Image _Image)
        {
            var _Res = _ResJson.ToEntity<XAIResBase>();
            using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.FACEDb)._DataAccess)
            {
                try
                {
                    var dbIdentLog = dbContext.Set<Db_IdentLog>().Where(w => w.Id == _RowId).ToList().FirstOrDefault();
                    if (dbIdentLog == null)
                        throw new Exception("The identlog that needs to be modified does not exist! id=" + _RowId);
                    dbIdentLog.ImageId = _Image.ImageId;
                    dbIdentLog.ImageType = "BASE64";
                    dbIdentLog.UserId = _Res.UserId;
                    dbIdentLog.Empi = _Res.Index;
                    dbIdentLog.ReturnCode = _Res.Code.ToInt();
                    dbIdentLog.ReturnDesc = _Res.Desc;
                    dbIdentLog.TimeOut = DateTime.Now;
                    dbIdentLog.ModDate = DateTime.Now;
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    LogModule.Error("Db Fail:" + ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message));
                }
            }
        }
    }
}
