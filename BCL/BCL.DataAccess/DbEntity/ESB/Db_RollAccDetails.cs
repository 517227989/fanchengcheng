using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_RollAccDetails
    {
        public int Id { get; set; }
        public String HospitalCode { get; set; }
        public String HospitalName { get; set; }
        public DateTime TradeDate { get; set; }
        public DateTime TradeTime { get; set; }
        public String TradeType { get; set; }
        public String CompanyCode { get; set; }
        public String CompanyName { get; set; }
        public String BranchCode { get; set; }
        public String BranchName { get; set; }
        public String TermCode { get; set; }
        public String TradeId { get; set; }
        public String HisTradeId { get; set; }
        public String HisBusinessId { get; set; }
        public String BatchNo { get; set; }
        public String MerchantId { get; set; }
        public String AccountBank { get; set; }
        public String OldTradeId { get; set; }
        public String OldHisTradeId { get; set; }
        public String OldBatchNo { get; set; }
        public String OldMerchantId { get; set; }
        public String TradeChannel { get; set; }
        public Decimal TradeAmount { get; set; }
        public String PatientId { get; set; }
        public String HisPatientId { get; set; }
        public String PaperWorkType { get; set; }
        public String PaperWorkNo { get; set; }
        public String VisitCardNo { get; set; }
        public String Name { get; set; }
        public Int32 State { get; set; }
        public Int32 Channel { get; set; }
        public String OtherDetail1 { get; set; }
        public String OtherDetail2 { get; set; }
    }
    public class Db_RollAccDetailsMapper : EntityTypeConfiguration<Db_RollAccDetails>
    {
        public Db_RollAccDetailsMapper()
        {
            ToTable("ST_RollAccDetails");
            HasKey(o => o.Id);
        }
    }
}
