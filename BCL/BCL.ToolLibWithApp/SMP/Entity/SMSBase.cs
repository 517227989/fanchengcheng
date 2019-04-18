using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.SMP.Entity
{
    public class SMSReqBase
    {
        public string SMSKind { get; set; }
        public string ReqNo { get; set; }
        public string PhoneNo { get; set; }
    }
    public class SMSResBase
    {
        public string ResCode { get; set; }
        public string ResMsg { get; set; }
    }
}
