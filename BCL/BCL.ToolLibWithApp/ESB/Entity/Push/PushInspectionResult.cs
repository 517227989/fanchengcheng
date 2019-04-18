using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Push
{
    public class ExternalReqPushInspectionResult : ExternalReqBase
    {
        public string PatientId { get; set; }
        public string InspectionResultId { get; set; }
    }

    public class ExternalResPushInspectionResult : ExternalResBase
    {

    }
}
