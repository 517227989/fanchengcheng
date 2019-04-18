using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.VAcc
{
    public class UPPReqPay:UPPReqBase
    {
        public string UserNo { get; set; }
        public string Amount { get; set; }
        public string ReqNo { get; set; }
        public string PayKind { get; set; }
    }
    public class UPPResPay : UPPResBase
    {
        public string UserNo { get; set; }
        public string PayDate { get; set; }
        public string PsNo { get; set; }
        public string ResNo { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
    }
}
