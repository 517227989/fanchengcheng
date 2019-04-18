using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.VAcc
{
    public class UPPReqRefundAcc:UPPReqBase
    {

        public string UserNo { get; set; }
        public string ReqNo { get; set; }
        public string OldReqNo { get; set; }
        public string OldPayDate { get; set; }
        public string Amount { get; set; }
    }
    public class UPPResRefundAcc : UPPResBase
    {
        public string UserNo { get; set; }
        public string RefundDate { get; set; }
        public string PsNo { get; set; }
        public string ResNo { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
    }
}
