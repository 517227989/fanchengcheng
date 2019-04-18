using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess
{
    public class Db_Satissurveyresult
    {
        public int Id { get; set; }
        public string Groups { get; set; }
        public string HospitalId { get; set; }
        public string IndexCode { get; set; }
        public string IndexName { get; set; }
        public int? Rating { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string TermCode { get; set; }
        public DateTime? SubmitDate { get; set; }
    }
    public class Db_SatissurveyresultMapper : EntityTypeConfiguration<Db_Satissurveyresult>
    {
        public Db_SatissurveyresultMapper()
        {
            ToTable("at_satissurveyresult");
            HasKey(o => o.Id);
        }
    }
}
