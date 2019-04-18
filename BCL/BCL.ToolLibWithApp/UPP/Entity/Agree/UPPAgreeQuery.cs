using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Agree
{
    public class UPPReqAgreeQuery
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public string Uid { get; set; }
        public string AgreeNo { get; set; }
    }
    public class UPPResAgreeQuery : UPPBizResBase
    {
        public string ValidTime { get; set; }
        public string InvalidTime { get; set; }
        public string AgreeNo { get; set; }
        public string Uid { get; set; }
        public string LoginId { get; set; }
        public int Status { get; set; }
        public string PCode { get; set; }
    }
}
