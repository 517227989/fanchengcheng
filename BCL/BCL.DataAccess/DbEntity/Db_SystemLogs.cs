using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess
{
    public class Db_SystemLogs : Db_Base
    {
        public string UserCode { get; set; }
        public string RequestUrl { get; set; }
        public string RequestParams { get; set; }
        public string ResponseParams { get; set; }
        public string TimeConsuming { get; set; }
    }
    public class Db_SystemLogsMapper:EntityTypeConfiguration<Db_SystemLogs>
    {
        public Db_SystemLogsMapper()
        {
            ToTable("UT_SystemLogs");
            HasKey(o => o.Id);
            Ignore(o => o.ModDate);
            Ignore(o => o.OperCode);
            Ignore(o => o.Remarks);
        }
    }
}
