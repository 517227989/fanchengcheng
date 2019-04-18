using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.VAcc
{
    public class UPPReqUnLoss:UPPReqBase
    {
        public string UserNo { get; set; }
        public string Name { get; set; }
        public string LossReason { get; set; }
    }
    public class UPPResUnLoss : UPPResBase
    {
    }
}
