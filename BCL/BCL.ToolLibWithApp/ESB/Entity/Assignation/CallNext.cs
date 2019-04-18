using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqCallNext : ExternalReqBase
    {
        public String RoomId { get; set; }
        public String DoctorCode { get; set; }
        public String CallType { get; set; }
        public String DeptCode { get; set; }
        public String TypeCode { get; set; }
    }
    public class ExternalResCallNext : ExternalResBase
    {
        public String QueueNo { get; set; }
        public String PatientId { get; set; }
        public String Name { get; set; }
        public String Number { get; set; }
        public String DeptCode { get; set; }
        public String DeptName { get; set; }
    }
}
