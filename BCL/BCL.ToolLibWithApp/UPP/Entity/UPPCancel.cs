using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity
{
    public class UPPReqCancel
    {
        public string ReqNo { get; set; }
        public string ResNo { get; set; }
    }

    public class UPPResCancel : UPPBizResBase
    {
        public string ReqNo { get; set; }
        public string ResNo { get; set; }
        public string State { get; set; }
    }
}
