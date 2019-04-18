using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_CpuDetails
    {
        public Int32 Id { get; set; }
        public String HospitalId { get; set; }
        public String ServerIp { get; set; }
        public DateTime AddDate { get; set; }
        public String Year { get; set; }
        public String Month { get; set; }
        public String Day { get; set; }
        public String Hour { get; set; }
        public String Minutes { get; set; }
        public String UsedPercent { get; set; }
    }
    public class Db_CpuDetailsMapper : EntityTypeConfiguration<Db_CpuDetails>
    {
        public Db_CpuDetailsMapper()
        {
            ToTable("MT_CpuDetails");
            HasKey(h => h.Id);
        }
    }
}
