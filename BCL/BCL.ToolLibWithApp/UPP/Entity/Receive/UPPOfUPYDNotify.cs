using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Receive
{
    public class UPPOfUPYDNotify
    {
        public BillPayment BillPayment { get; set; }
        public string billPayment { get; set; }
        public string billDesc { get; set; }
        public string gn { get; set; }
        public string sign { get; set; }
        public string merName { get; set; }
        public string mid { get; set; }
        public string billDate { get; set; }
        public string qrCodeType { get; set; }
        public string tid { get; set; }
        public string instMid { get; set; }
        public string totalAmount { get; set; }
        public string createTime { get; set; }
        public string billStatus { get; set; }
        public string notifyId { get; set; }
        public string billNo { get; set; }
        public string subInst { get; set; }
        public string billQRCode { get; set; }
        public string memberId { get; set; }
        public string counterNo { get; set; }
        public string memo { get; set; }
        public string goodsTradeNo { get; set; }
        public string secureStatus { get; set; }
        public string completeAmount { get; set; }
        public UPPOfUPYDNotify()
        {
            BillPayment = new BillPayment();
        }
    }
    public class BillPayment
    {

        public string payTime { get; set; }
        public string paySeqId { get; set; }
        public string invoiceAmount { get; set; }
        public string settleDate { get; set; }
        public string buyerId { get; set; }
        public string totalAmount { get; set; }
        public string couponAmount { get; set; }
        public string billBizType { get; set; }
        public string buyerPayAmount { get; set; }
        public string targetOrderId { get; set; }
        public string payDetail { get; set; }
        public string merOrderId { get; set; }
        public string status { get; set; }
        public string targetSys { get; set; }
    }
}
