using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqExamLogin : ExternalReqBase
    {
        public String DoctorCode { get; set; }
        public String Password { get; set; }
    }
    public class ExternalResExamLogin : ExternalResBase
    {
        public String DoctorCode { get; set; }
    }
}
