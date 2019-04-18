using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_TradeDetail
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string TradeType { get; set; }
        public string TradeName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public DateTime TradeTime { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public Decimal TradeAmount { get; set; }
        public string PhoneNo { get; set; }
        public string PaperWorkType { get; set; }
        public string PaperWorkNo { get; set; }
    }
    public class Db_TradeDetailMapper : EntityTypeConfiguration<Db_TradeDetail>
    {
        public Db_TradeDetailMapper()
        {
            ToTable("RT_TradeDetail");
            HasKey(o => o.Id);
        }
    }
}
