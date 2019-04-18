using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Package
    {
        public string HospitalId { get; set; }
        public string PackageCode { get; set; }
        public string MediCode { get; set; }
        public string MediName { get; set; }
        public string MediCalssifyCode { get; set; }
        public string MediClassifyName { get; set; }
        public decimal MediPrice { get; set; }
        public string MediUnit { get; set; }
        public string MediLevel { get; set; }
        public decimal? ItemPayRatio { get; set; }
    }
    public class Db_PackageMapper : EntityTypeConfiguration<Db_Package>
    {
        public Db_PackageMapper()
        {
            ToTable("AT_Packages");
            HasKey(k => new { k.HospitalId, k.MediCode, k.PackageCode });
        }
    }
}
