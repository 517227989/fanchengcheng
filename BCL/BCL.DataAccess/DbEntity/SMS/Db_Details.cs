using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess.DbEntity.SMS
{
    public class Db_Details
    {
        public int Id { get; set; }
        public string SMSKind { get; set; }
        public string PhoneNo { get; set; }
        public string SignName { get; set; }
        public string TempCode { get; set; }
        public string TempArgs { get; set; }
        public string Content { get; set; }
        public string ReqNo { get; set; }
        public string ResNo { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime? RecvDate { get; set; }
        public string ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public string State { get; set; }
        public DateTime AddDate { get; set; }
    }
    public class Db_DetailsMapper : EntityTypeConfiguration<Db_Details>
    {
        public Db_DetailsMapper()
        {
            ToTable("SMS_Details");
            HasKey(o => o.Id);
        }
    }
}
