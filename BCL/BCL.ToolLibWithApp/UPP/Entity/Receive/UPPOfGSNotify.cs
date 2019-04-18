using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Receive
{
    public class UPPOfGSNotify
    {
        public string respCode { get; set; }
        public string respMsg { get; set; }
        public string signMethod { get; set; }
        public string certId { get; set; }
        public string signAture { get; set; }
        public string txnOrderId { get; set; }
        public string txnOrderTime { get; set; }
        public string merId { get; set; }
        public string respTxnSsn { get; set; }
        public string respTxnTime { get; set; }
        public string settleAmt { get; set; }
        public string settleCcyType { get; set; }
        public string settleDate { get; set; }
        public string txnPayWay { get; set; }
        public string txnPayName { get; set; }
    }
}
