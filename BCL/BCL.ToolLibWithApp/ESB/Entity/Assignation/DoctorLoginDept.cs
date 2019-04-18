using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqDoctorLoginDept : ExternalReqBase
    {
        public String DoctorCode { get; set; }
    }
    public class ExternalResDoctorLoginDept : ExternalResBase
    {
        public List<DoctorDeptInfo> DeptList { get; set; }
    }
    public class DoctorDeptInfo
    {
        public String DeptName { get; set; }
        public String DeptCode { get; set; }
        public int OrderNum { get; set; }
    }
}
