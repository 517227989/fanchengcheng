using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqQueueAdjust : ExternalReqBase
    {
        public String PatientId { get; set; }
        public String DoctorCode { get; set; }
        public String AdjustPosition { get; set; }
        public String BusinessId { get; set; }

    }
    public class ExternalResQueueAdjust : ExternalResBase
    {
        public String QueueNo { get; set; }

    }
}
