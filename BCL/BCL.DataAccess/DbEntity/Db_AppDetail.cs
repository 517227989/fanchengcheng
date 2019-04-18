using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess
{
    public class Db_AppDetail : Db_Base
    {
        public string AppCode { get; set; }
        public string HosCode { get; set; }
        public string DevCode { get; set; }
        public string AppId { get; set; }
        public string Title { get; set; }
        public string UserNo { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public DateTime ReqDate { get; set; }
        public string ReqNo { get; set; }
        public DateTime PsDate { get; set; }
        public string PsNo { get; set; }
        public DateTime ResDate { get; set; }
        public string ResNo { get; set; }
        public Decimal Amount { get; set; }
        public string Mode { get; set; }
        public string Class { get; set; }
        public string ReqChannel { get; set; }
        public string BusValue { get; set; }
        public int State { get; set; }
        public string PayType { get; set; }
        public int IsPolled { get; set; }
        public string AuthCode { get; set; }
        public string TermCode { get; set; }
    }
    public class Db_AppDetailMapper : EntityTypeConfiguration<Db_AppDetail>
    {
        public Db_AppDetailMapper()
        {
            ToTable("UT_AppDetail");
            HasKey(o => o.Id);
        }
    }
}
