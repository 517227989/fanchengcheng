using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqCallAgain : ExternalReqBase
    {
        public String RoomId { get; set; }
        public String DoctorCode { get; set; }
        public string DeptCode { get; set; }
        public string TypeCode { get; set; }
        public string BusinessId { get; set; }
    }
    public class ExternalResCallAgain : ExternalResBase
    {
        public String PatientId { get; set; }
        public String QueueNo { get; set; }
        public String Name { get; set; }
        public String Number { get; set; }
    }
}
