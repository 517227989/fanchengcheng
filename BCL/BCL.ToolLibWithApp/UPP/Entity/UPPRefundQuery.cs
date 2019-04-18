using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity
{
    public class UPPReqRefundQuery
    {
        public string OldReqNo { get; set; }
        public string ResNo { get; set; }
        public string TradeType { get; set; }
    }
    public class UPPResRefundQuery : UPPBizResBase
    {
        public string OldReqNo { get; set; }
        public string PayAmount { get; set; }
        public string RefundTotalAmount { get; set; }
        public string RefundCount { get; set; }
        public List<RefundInfo> RefundList { get; set; }
        public UPPResRefundQuery()
        {
            RefundList = new List<RefundInfo>();
        }
    }
    public class RefundInfo
    {
        public string ReqNo { get; set; }
        public string ResNo { get; set; }
        public string RefundAmount { get; set; }
        public string RefundDate { get; set; }

    }
}
