using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqCheckFeasibility : ExternalReqBase
    {
        //deptCode，typeCode，doctorCode，cardType，cardInfo，
        public String DeptCode { get; set; }
        public String TypeCode { get; set; }
        public String DoctorCode { get; set; }
        public String CardType { get; set; }
        public String CardInfo { get; set; }
    }

    public enum FeasibilityResult
    {
        正常,
        评估,
        禁止报到
    }

    public class ExternalResCheckFeasibility : ExternalResBase
    {
        public string Result { get; set; }
    }
}
