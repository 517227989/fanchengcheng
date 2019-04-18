using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.VAcc
{
    public class UPPReqRevoke:UPPReqBase
    {
        public string UserNo { get; set; }
        public string Amount { get; set; }
        public string ReqNo { get; set; }
        public string OldReqNo { get; set; }
    }
    public class UPPResRevoke : UPPResBase
    {
        public string AccNo { get; set; }
        public string RevokeDate { get; set; }
        public string PsNo { get; set; }
        public string ResNo { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
    }
}
