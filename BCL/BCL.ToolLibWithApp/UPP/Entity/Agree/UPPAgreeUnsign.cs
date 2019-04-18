using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Agree
{
    public class UPPReqAgreeUnsign
    {
        public string AgreeNo { get; set; }
        public string Uid { get; set; }
        public string NotifyUrl { get; set; }
    }
    public class UPPResAgreeUnsign : UPPBizResBase
    {
    }
}
