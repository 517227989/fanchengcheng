using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqGetVar : ExternalReqBase
    {
        public String ParaName { get; set; }
    }
    public class ExternalResGetVar : ExternalResBase
    {
        public String DefeultVal { get; set; }
    }
}
