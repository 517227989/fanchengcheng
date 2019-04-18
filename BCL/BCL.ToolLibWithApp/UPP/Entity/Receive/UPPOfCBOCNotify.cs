using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Receive
{
    public class UPPOfCBOCNotify
    {

        public string hostTime { get; set; }
        public string orderNo { get; set; }
        public string merchantId { get; set; }
        public string outTradeNo { get; set; }
        public string clientIp { get; set; }
        public string transAmt { get; set; }
        public string channel { get; set; }
        public string sign { get; set; }
        public string channelOrderNo { get; set; }
        public string backType { get; set; }
        public string terminalId { get; set; }
        public string transStatus { get; set; }
        public string nonceStr { get; set; }
    }
}
