using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqExamCheckedPatientList : ExternalReqBase
    {
        public String DeptCode { get; set; }
    }
    public class ExternalResExamCheckedPatientList : ExternalResBase
    {
        public String WaitPatientCount { get; set; }
        public List<CheckPatientInfo> CheckPatList { get; set; }
    }
}
