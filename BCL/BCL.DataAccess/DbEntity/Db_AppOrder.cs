using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess
{
    public class Db_AppOrder : Db_Base
    {
        public string AppCode { get; set; }
        public int Mode { get; set; }
        public string Class { get; set; }
        public string Kind { get; set; }
        public string AppId { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string PSNo { get; set; }
        public string ReqNo { get; set; }
        public string OldReqNo { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string BackParams { get; set; }
        public string ResNo { get; set; }
        public string OrderInfo { get; set; }
        public string NotifyUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string ReqChannel { get; set; }
        public DateTime ReqDate { get; set; }
        public int State { get; set; }
        public string TimeExpire { get; set; }
        public string Reason { get; set; }
        public int IsCanUpdateAmount { get; set; }
        public int IsPolled { get; set; }
        public string TermCode { get; set; }
    }
    public class Db_AppOrderMapper : EntityTypeConfiguration<Db_AppOrder>
    {
        public Db_AppOrderMapper()
        {
            ToTable("UT_AppOrder");
            HasKey(o => o.Id);
        }
    }
}
