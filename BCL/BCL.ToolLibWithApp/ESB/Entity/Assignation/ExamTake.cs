using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqExamTake : ExternalReqBase
    {
        public String DeptCode { get; set; }
    }
    public class ExternalResExamTake : ExternalResBase
    {
        public String Number { get; set; }
    }
}
