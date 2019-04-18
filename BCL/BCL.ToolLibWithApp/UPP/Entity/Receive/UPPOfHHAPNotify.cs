using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Receive
{
    public class UPPOfHHAPNotify
    {
        public string MerId { get; set; }
        public string TermId { get; set; }
        public string QrCode { get; set; }
        public string QrOrderNo { get; set; }
        public string MerOrderNo { get; set; }
        public string TranId { get; set; }
        public string PayType { get; set; }
        public string BankDate { get; set; }
        public string BankTime { get; set; }
        public string RespCode { get; set; }
        public string RespMsg { get; set; }
        public string TradeNo { get; set; }
        public string TradeId { get; set; }
        public string PayVounum { get; set; }
        public string PayNo { get; set; }
        public string CcyCode { get; set; }
        public string TranAmt { get; set; }
        public string DisPrice { get; set; }
        
    }
}
