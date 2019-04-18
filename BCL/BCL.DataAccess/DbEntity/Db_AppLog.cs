using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess
{
    public class Db_AppLog : Db_Base
    {
        public string Kind { get; set; }
        public string AppId { get; set; }
        public DateTime ReqTime { get; set; }
        public string Channel { get; set; }
        public string NotifyUrl { get; set; }
        public string Mode { get; set; }
        public string Class { get; set; }
        public string ReqArgs { get; set; }
        public string ReqRandom { get; set; }
        public string ReqSign { get; set; }
        public string Code { get; set; }
        public string Msg { get; set; }
        public DateTime? ResTime { get; set; }
        public string ResArgs { get; set; }
        public string ResRandom { get; set; }
        public string ResSign { get; set; }
        public string TermCode { get; set; }
    }
    public class Db_AppLogMapper : EntityTypeConfiguration<Db_AppLog>
    {
        public Db_AppLogMapper()
        {
            ToTable("UT_AppLog");
            HasKey(o => o.Id);
        }
    }
}
