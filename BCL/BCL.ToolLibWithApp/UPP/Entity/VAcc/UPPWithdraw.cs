using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.VAcc
{
    public class UPPReqWithdraw:UPPReqBase
    {
        public string UserNo { get; set; }
        public string Amount { get; set; }
        public string ReqNo { get; set; }
        public string WithdrawKind { get; set; }
        public string Name { get; set; }
        public string PaperWorkType { get; set; }
        public string PaperWorkNo { get; set; }
        public string Mac { get; set; }
    }
    public class UPPResWithdraw : UPPResBase
    {
        public string UserNo { get; set; }
        public string WithdrawDate { get; set; }
        public string PsNo { get; set; }
        public string ResNo { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
    }
}
