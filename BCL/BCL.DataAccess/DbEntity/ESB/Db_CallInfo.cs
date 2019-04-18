using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_CallInfo
    {
        public int Id { get; set; }
        public string HospitalId { get; set; }
        public string ScreenId { get; set; }
        public string ScreenName { get; set; }
        public int CallStatus { get; set; }
        public DateTime ModDate { get; set; }
        public string BusinessType { get; set; }
        public string BusinessId { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string Detail3 { get; set; }
        public string Detail4 { get; set; }
        public string Detail5 { get; set; }
        public string Detail6 { get; set; }
        public string Detail7 { get; set; }
        public string Detail8 { get; set; }
        public string Detail9 { get; set; }
        public string Detail10 { get; set; }
    }
    public class Db_CallInfoMapper : EntityTypeConfiguration<Db_CallInfo>
    {
        public Db_CallInfoMapper()
        {
            ToTable("AT_CallInfo");
            HasKey(k => new { k.HospitalId, k.Id });
        }
    }
}
