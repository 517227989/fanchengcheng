using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess
{
    public class Db_MisPosRefund
    {
        public int Id { get; set; }
        public string HospitalId { get; set; }
        public string TermCode { get; set; }
        public string Amount { get; set; }
        public string ResNo { get; set; }
        public int State { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime ModDate { get; set; }
        public string Remark { get; set; }
    }
    public class Db_MisPosRefundMapper : EntityTypeConfiguration<Db_MisPosRefund>
    {
        public Db_MisPosRefundMapper()
        {
            ToTable("AT_MisPosRefund");
            HasKey(o => o.Id);
        }
    }
}
