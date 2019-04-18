using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Agree
{
    public class UPPReqAgreeSign
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public string SignType { get; set; }
        public string SignTime { get; set; }
        public string NotifyUrl { get; set; }
    }
    public class UPPResAgreeSign : UPPBizResBase
    {
        public string PageInfo { get; set; }
    }
}
