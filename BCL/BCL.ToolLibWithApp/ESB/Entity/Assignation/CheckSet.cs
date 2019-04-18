using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqCheckSet : ExternalReqBase
    {
        public String DoctorCode { get; set; }
        public String CheckLimitAM { get; set; }
        public String CheckLimitPM { get; set; }
    }
    public class ExternalResCheckSet : ExternalResBase
    {
    }
}
