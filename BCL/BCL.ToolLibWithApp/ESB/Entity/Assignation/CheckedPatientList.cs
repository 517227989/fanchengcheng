using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqCheckedPatientList : ExternalReqBase
    {
        public String DoctorCode { get; set; }
        public String RoomId { get; set; }
        public String DeptCode { get; set; }
        public String TypeCode { get; set; }
    }
    public class ExternalResCheckedPatientList : ExternalResBase
    {
        public String NowPatCount { get; set; }
        public String AlreadyPatCount { get; set; }
        public List<CheckPatientInfo> CheckPatientList { get; set; }
    }
    public class CheckPatientInfo
    {
        public String Number { get; set; }
        public String Name { get; set; }
        public String QueueState { get; set; }
        public string SpecFlag { get; set; }
        public String QueueNo { get; set; }
        public String CallDate { get; set; }
        public String BusinessId { get; set; }
    }
}
