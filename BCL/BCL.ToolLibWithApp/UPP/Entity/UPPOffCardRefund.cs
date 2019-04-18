using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity
{
    public class UPPReqOffCardRefund
    {
        public string InData { get; set; }
    }

    public class UPPResOffCardRefund : UPPBizResBase
    {
        public string OutData { get; set; }
    }
}
