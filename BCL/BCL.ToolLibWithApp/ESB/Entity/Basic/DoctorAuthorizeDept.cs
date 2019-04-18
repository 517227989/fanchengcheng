using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Basic
{
    public class ExternalReqDoctorAuthorizeDept : ExternalReqBase
    {
    }

    public class ExternalResDoctorAuthorizeDept : ExternalResBase
    {
        public ExternalResDoctorAuthorizeDept()
        {
            DoctorAuthorizeDeptList = new List<DoctorAuthorizeDeptInfo>();
        }

        public List<DoctorAuthorizeDeptInfo> DoctorAuthorizeDeptList { get; set; }
    }

    public class DoctorAuthorizeDeptInfo
    {
        public string HospitalId { get; set; }
        public string DoctorCode { get; set; }
        public string DoctorName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
    }
}
