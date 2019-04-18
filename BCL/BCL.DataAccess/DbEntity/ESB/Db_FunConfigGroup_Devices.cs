using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_FunConfigGroup_Devices
    {
        public Int32 Id { get; set; }
        public String GroupId { get; set; }
        public String DeviceId { get; set; }
        public String HospitalId { get; set; }
        public DateTime AddDate { get; set; }
        public String OperCode { get; set; }
        public String OperName { get; set; }
        public String TermCode { get; set; }
    }
    public class Db_FunConfigGroup_DevicesMapper : EntityTypeConfiguration<Db_FunConfigGroup_Devices>
    {
        public Db_FunConfigGroup_DevicesMapper()
        {
            ToTable("CT_FunConfigGroup_Devices");
            HasKey(o => o.Id);
        }
    }
}
