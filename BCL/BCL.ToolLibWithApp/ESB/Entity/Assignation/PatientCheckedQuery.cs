using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqPatientCheckedQuery : ExternalReqBase
    {
        public String CardType { get; set; }
        public String CardNo { get; set; }
    }
    public class ExternalResPatientCheckedQuery : ExternalResBase
    {
        public List<PatientCheckedQueryInfo> PatientCheckedQueryInfoList { get; set; }
    }
    public class PatientCheckedQueryInfo
    {
        public String PatientId { get; set; }
        public String Name { get; set; }
        public String DeptName { get; set; }
        public String DeptLocation { get; set; }
        public String DoctorName { get; set; }
        public String AverageTime { get; set; }
        public String SerialNum { get; set; }
        public String CurrentNum { get; set; }
        public String FrontNum { get; set; }
        public String ExpectTime { get; set; }
        public List<WantPatientInfo> WantPatientInfo { get; set; }
    }
    public class WantPatientInfo
    {
        public String Name { get; set; }
        public String Number { get; set; }
    }
}
