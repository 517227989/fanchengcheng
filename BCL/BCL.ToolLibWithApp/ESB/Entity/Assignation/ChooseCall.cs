using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqChooseCall : ExternalReqBase
    {
        public String RoomId { get; set; }
        public String DoctorCode { get; set; }
        public String CallType { get; set; }
        public String BusinessId { get; set; }
        public string DeptCode { get; set; }
        public string TypeCode { get; set; }
    }
    public class ExternalResChooseCall : ExternalResBase
    {
        public String QueueNo { get; set; }
        public String PatientId { get; set; }
        public String Name { get; set; }
        public String Number { get; set; }
    }
}
