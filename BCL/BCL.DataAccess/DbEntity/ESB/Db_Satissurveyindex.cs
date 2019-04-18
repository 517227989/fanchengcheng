using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Satissurveyindex
    {
        public int Id { get; set; }
        public string Groups { get; set; }
        public string HospitalId { get; set; }
        public string IndexCode { get; set; }
        public string IndexName { get; set; }
        public int? OrderNum { get; set; }
        public int IsCancel { get; set; }
        public string OperCode { get; set; }
        public DateTime? ModDate { get; set; }
    }
    public class Db_SatissurveyindexMapper : EntityTypeConfiguration<Db_Satissurveyindex>
    {
        public Db_SatissurveyindexMapper()
        {
            ToTable("ct_satissurveyindex");
            HasKey(k => new { k.Id });
        }
    }
}
