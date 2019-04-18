using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqExamLoginDept : ExternalReqBase
    {
        public String DeptType { get; set; }
    }
    public class ExternalResExamLoginDept : ExternalResBase
    {
        public List<DoctorDeptInfo> DeptList { get; set; }
    }
}
