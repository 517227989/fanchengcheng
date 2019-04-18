using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity
{
    public class UPPReqQuery 
    {
        public string ReqNo { get; set; }
        public string ResNo { get; set; }
        public string TradeType { get; set; }
        public DateTime AddDate { get; set; }
    }
    public class UPPResQuery : UPPBizResBase
    {
        public string ReqNo { get; set; }
        public string ResNo { get; set; }
        public string Amount { get; set; }
        public string State { get; set; }
        public string SendDate { get; set; }
        public string Mode { get; set; }
    }

}
