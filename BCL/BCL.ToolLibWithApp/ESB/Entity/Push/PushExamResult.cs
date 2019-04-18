using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Push
{
    public class ExternalReqPushExamResult : ExternalReqBase
    {
        public string PatientId { get; set; }
        public string ExamResultId { get; set; }
    }

    public class ExternalResPushExamResult : ExternalResBase
    {

    }
}
