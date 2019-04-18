using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using BCL.ToolLib;
using Dapper;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_TradeLog
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string HospitalId { get; set; }
        public string CompanyCode { get; set; }
        public string TradeType { get; set; }
        public string ReqMsg { get; set; }
        public string ResMsg { get; set; }
        public string RetCode { get; set; }
        public DateTime ReqTime { get; set; }
        public DateTime? ResTime { get; set; }
        public int TradeState { get; set; }
        public int UploadState { get; set; }
    }
    public class Db_TradeLogMapper : EntityTypeConfiguration<Db_TradeLog>
    {
        public Db_TradeLogMapper()
        {
            var _TableName = "SubTable".ConfigValue("NO") == "YES" ? "AT_TradeLog_" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") : "AT_TradeLog";
            if ("SubTable".ConfigValue("NO") == "YES")
            {
                using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.HPDb)._DataAccess)
                {
                    var x = dbContext.Database.Connection.Query("SELECT TABLE_NAME FROM information_schema.TABLES WHERE table_name = '" + _TableName + "'");
                    if (x.Count() == 0)
                    {
                        dbContext.Database.Connection.Execute(String.Format(@"CREATE TABLE `{0}` (
                                                            `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
                                                            `Guid` varchar(50) NOT NULL COMMENT '消息Id',
                                                            `HospitalId` varchar(5) NOT NULL COMMENT '医院Id',
                                                            `CompanyCode` varchar(45) NOT NULL COMMENT '厂商代码',
                                                            `TradeType` varchar(60) NOT NULL COMMENT '交易类型',
                                                            `ReqMsg` longtext NOT NULL COMMENT '请求串',
                                                            `ResMsg` longtext COMMENT '返回串',
                                                            `RetCode` varchar(10) DEFAULT NULL COMMENT '交易返回码',
                                                            `ReqTime` datetime NOT NULL COMMENT '请求时间',
                                                            `ResTime` datetime DEFAULT NULL COMMENT '响应时间',
                                                            `TradeState` int(11) NOT NULL DEFAULT '0' COMMENT '0->交易正在请求中 1->交易请求完成 -99->非法或异常请求',
                                                            `UploadState` int(11) NOT NULL DEFAULT '0' COMMENT '0->未提取 1->已提取 2->已上传',
                                                            PRIMARY KEY (`Id`),
                                                            UNIQUE KEY `Id_UNIQUE` (`Id`),
                                                            UNIQUE KEY `Guid_UNIQUE` (`Guid`),
                                                            KEY `idx_{0}_ReqTime` (`ReqTime`)
                                                        ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;", _TableName));
                    }
                }
            }
            ToTable(_TableName);
            HasKey(o => o.Id);
        }
    }
}
