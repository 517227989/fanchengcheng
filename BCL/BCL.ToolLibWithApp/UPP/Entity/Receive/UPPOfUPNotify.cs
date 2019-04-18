using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Receive
{
    public class UPPOfUPNotify
    {
        public string mid { get; set; }
        public string tid { get; set; }
        public string instMid { get; set; }
        public string attachedData { get; set; }
        public string bankCardNo { get; set; }
        public string bankInfo { get; set; }
        public string billFunds { get; set; }
        public string billFundsDesc { get; set; }
        public string buyerId { get; set; }
        public string buyerUsername { get; set; }
        public string couponAmount { get; set; }
        public string buyerPayAmount { get; set; }
        public string totalAmount { get; set; }
        public string invoiceAmount { get; set; }
        public string merOrderId { get; set; }
        public string payTime { get; set; }
        public string receiptAmount { get; set; }
        public string refId { get; set; }
        public string refundAmount { get; set; }
        public string refundDesc { get; set; }
        public string seqId { get; set; }
        public string settleDate { get; set; }
        public string status { get; set; }
        public string subBuyerId { get; set; }
        public string targetOrderId { get; set; }
        public string targetSys { get; set; }
        public string notifyId { get; set; }
        public string sign { get; set; }
    }
}
