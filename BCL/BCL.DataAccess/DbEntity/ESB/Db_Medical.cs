using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Medical
    {
        public string HospitalId { get; set; }
        public string BranchCode { get; set; }
        public string MediCode { get; set; }
        public string MediName { get; set; }
        public string MediCalssifyCode { get; set; }
        public string MediClassifyName { get; set; }
        public decimal MediPrice { get; set; }
        public string MediUnit { get; set; }
        public string MediLevel { get; set; }
        public decimal? ItemPayRatio { get; set; }
        public int IsPackage { get; set; }
        public string QuickCode { get; set; }
    }
    public class Db_MedicalMapper : EntityTypeConfiguration<Db_Medical>
    {
        public Db_MedicalMapper()
        {
            ToTable("AT_Medicals");
            HasKey(k => new { k.HospitalId, k.MediCode });
        }
    }
}
