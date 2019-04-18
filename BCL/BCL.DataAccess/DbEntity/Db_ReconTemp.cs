using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess
{
    public class Db_ReconTemp
    {
        public int Id { get; set; }
        public string HospitalId { get; set; }
        public string TCode { get; set; }
        public string TName { get; set; }
        public int HNo { get; set; }
        public string HTitle { get; set; }
        public string HValue { get; set; }
        public int HCompute { get; set; }
        public int CNo { get; set; }
        public string CTitle { get; set; }
        public string CValue { get; set; }
        public int CCompute { get; set; }
        public string Style { get; set; }
    }
    public class Db_ReconTempMapper : EntityTypeConfiguration<Db_ReconTemp>
    {
        public Db_ReconTempMapper()
        {
            ToTable("UT_ReconTemp");
            HasKey(o => o.Id);
        }
    }
}
