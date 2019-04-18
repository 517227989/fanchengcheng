using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.RollingAcc
{
    public class ExternalReqRollAcc : ExternalReqBase
    {

    }

    public class ExternalResRollAcc : ExternalResBase
    {
        public List<PayDetails> PayDetails { get; set; }
        public ExternalResRollAcc()
        {
            PayDetails = new List<PayDetails>();
        }
    }
    public class PayDetails
    {
        public String HospitalCode { get; set; }
        public String HospitalName { get; set; }
        public String TradeDate { get; set; }
        public String TradeTime { get; set; }
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
        public String TradeAmount { get; set; }
        public String PatientId { get; set; }
        public String HisPatientId { get; set; }
        public String PaperWorkType { get; set; }
        public String PaperWorkNo { get; set; }
        public String VisitCardNo { get; set; }
        public String Name { get; set; }
        public String State { get; set; }
        public String OtherDetail1 { get; set; }
        public String OtherDetail2 { get; set; }
    }
}
