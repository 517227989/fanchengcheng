using BCL.DataAccess;
using BCL.ToolLib;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.UPP.Entity;
using Dapper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP
{
    public static class UPPDbConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="appCode"></param>
        /// <returns></returns>
        public static IEnumerable<Db_AppLink> DbAppLink(this DbContextEx dbContext, string appCode)
        {
            return dbContext.DbAppLink("SELECT * " +
                                         "FROM UT_AppLink " +
                                        "WHERE AppCode = @AppCode " +
                                          "AND Active = 0 ",
                                       new { AppCode = appCode });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="appId"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Db_AppLink DbAppLink(this DbContextEx dbContext, string appId, int mode)
        {
            return dbContext.DbAppLink("SELECT * " +
                                         "FROM UT_AppLink " +
                                        "WHERE AppId = @AppId " +
                                          "AND Mode = @LinkMode " +
                                          "AND Active = 0 ",
                                        new
                                        {
                                            AppId = appId,
                                            LinkMode = mode
                                        }).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="appCode"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Db_AppLink DbAppLink(this DbContextEx dbContext, string appCode, string mode)
        {
            return dbContext.DbAppLink("SELECT * " +
                                         "FROM UT_AppLink " +
                                        "WHERE AppCode = @AppCode " +
                                          "AND Mode = @LinkMode " +
                                          "AND Active = 0 ",
                                        new
                                        {
                                            AppCode = appCode,
                                            LinkMode = mode
                                        }).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dynamicSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static IEnumerable<Db_AppLink> DbAppLink(this DbContextEx dbContext, string dynamicSql, object param = null)
        {
            var dbAppLink = dbContext.Database.Connection.Query<Db_AppLink>(dynamicSql, param);
            if (dbAppLink == null || dbAppLink.Count() == 0)
                throw new Exception("未开通或未激活,不具备调用条件!");
            return dbAppLink;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DbAppCache"></param>
        public static void DbAppConfig(this ConcurrentDictionary<String, Db_App> _DbAppCache)
        {
            lock (_DbAppCache)
            {
                using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.UPPDb)._DataAccess)
                {
                    dbContext.Database.Connection.Query<Db_App>("SELECT * FROM UT_App WHERE Active = 0").ToList().ForEach(o =>
                    {
                        _DbAppCache.AddOrUpdate(o.AppCode, o, (key, value) => value);
                    });
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void AddSingleRow(this UPPReqBase req)
        {
            using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.UPPDb)._DataAccess)
            {
                try
                {
                    var dbReq = new Db_AppLog
                    {
                        AppId = req.AppId,
                        Channel = req.Channel,
                        Class = req.Class,
                        Kind = req.Kind,
                        Mode = req.Mode,
                        OperCode = req.OperCode,
                        ReqTime = Convert.ToDateTime(req.ReqTime),
                        TermCode = req.TermCode,
                        ReqArgs = req.Args,
                        ReqRandom = req.Random,
                        ReqSign = req.Sign,
                        AddDate = DateTime.Now
                    };
                    dbContext.Entry(dbReq).State = EntityState.Added;
                    dbContext.SaveChanges();
                    req.RowId = dbReq.Id;
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
        public static void ModSingleRow(this UPPResBase res, UPPReqBase req)
        {
            using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.UPPDb)._DataAccess)
            {
                try
                {
                    var dbRow = dbContext.Set<Db_AppLog>().Where(w => w.Id == req.RowId).ToList().FirstOrDefault();
                    if (dbRow == null)
                        throw new Exception("The line that needs to be modified does not exist!");
                    dbRow.Code = res.ResCode;
                    dbRow.Msg = res.ResMsg;
                    dbRow.ResTime = Convert.ToDateTime(res.ResTime);
                    dbRow.ResArgs = res.Args;
                    dbRow.ResRandom = res.Random;
                    dbRow.ResSign = res.Sign;
                    dbRow.ModDate = DateTime.Now;
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
