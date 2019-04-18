using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Receive
{
    public class UPPOfUPQRCNotify
    {
        public string queryId { get; set; }
        public string traceTime { get; set; }
        public string signature { get; set; }
        public string signMethod { get; set; }
        public string traceNo { get; set; }
        public string respCode { get; set; }
        public string respMsg { get; set; }
        public string exchangeDate { get; set; }
        public string issInsNo { get; set; }
        public string accInsCode { get; set; }
        public string signPubKeyCert { get; set; }
        public string settleCurrencyCode { get; set; }
        public string exchangeRate { get; set; }
        public string settleAmt { get; set; }
        public string settleDate { get; set; }
        public string customerInfo { get; set; }
        public string accNo { get; set; }
        public string payType { get; set; }
        public string payCardType { get; set; }
        public string version { get; set; }
        public string encoding { get; set; }
        public string bizType { get; set; }
        public string txnTime { get; set; }
        public string currencyCode { get; set; }
        public string txnAmt { get; set; }
        public string txnType { get; set; }
        public string txnSubType { get; set; }
        public string accessType { get; set; }
        public string reqReserved { get; set; }
        public string merId { get; set; }
        public string orderId { get; set; }
        public string reserved { get; set; }
    }
}
