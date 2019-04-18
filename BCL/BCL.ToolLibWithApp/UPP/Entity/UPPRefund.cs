using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity
{
    public class UPPReqRefund
    {
        public string ReqNo { get; set; }
        public string ResNo { get; set; }
        public string PSNo { get; set; }
        public string TotalAmount { get; set; }
        public string Amount { get; set; }
        public string Reason { get; set; }
        public string TradeType { get; set; }
        public string PayType { get; set; }
        public DateTime ResDate { get; set; }
        public string NotifyUrl { get; set; }
    }

    public class UPPResRefund : UPPBizResBase
    {
        public string ReqNo { get; set; }
        public string ResNo { get; set; }
        public string Amount { get; set; }
        public string EffectTime { get; set; }
        public string UserNo { get; set; }
    }
}
