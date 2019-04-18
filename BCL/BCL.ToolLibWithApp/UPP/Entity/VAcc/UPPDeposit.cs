using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.VAcc
{
    public class UPPReqDeposit:UPPReqBase
    {
        public string UserNo { get; set; }
        public string Amount { get; set; }
        public string ReqNo { get; set; }
        public string DepositKind { get; set; }
        public string Mac { get; set; }
    }
    public class UPPResDeposit : UPPReqBase
    {
        public string UserNo { get; set; }
        public string DepositDate { get; set; }
        public string PsNo { get; set; }
        public string ResNo { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
        public string OrderUrl { get; set; }
    }
}
