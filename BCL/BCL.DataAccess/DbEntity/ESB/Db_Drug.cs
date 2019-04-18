using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Drug
    {
        public string HospitalId { get; set; }
        public string BranchCode { get; set; }
        public string DrugCode { get; set; }
        public string DrugName { get; set; }
        public string DrugPlaceCode { get; set; }
        public string DrugPlaceName { get; set; }
        public string DrugClassifyCode { get; set; }
        public string DrugClassifyName { get; set; }
        public decimal DrugPrice { get; set; }
        public string DrugSpecification { get; set; }
        public string MediLevel { get; set; }
        public decimal? ItemPayRatio { get; set; }
        public string QuickCode { get; set; }
    }
    public class Db_DrugMapper : EntityTypeConfiguration<Db_Drug>
    {
        public Db_DrugMapper()
        {
            ToTable("AT_Drugs");
            HasKey(k => new { k.HospitalId, k.DrugCode, k.DrugPlaceCode });
        }
    }
}
