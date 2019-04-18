using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.VAcc
{
    public class UPPReqOff:UPPReqBase
    {
        public string UserNo { get; set; }
        public string OffReason { get; set; }
    }
    public class UPPResOff : UPPResBase
    {
    }
}
