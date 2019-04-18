using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Refund
{
    public class ExternalReqRefund : ExternalReqBase
    {
        public String PatientId { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String PayId { get; set; }
        public String Amount { get; set; }
    }
    public class ExternalResRefund : ExternalResBase
    {
        public String RefundId { get; set; }
    }
}
