using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqDoctorState : ExternalReqBase
    {
        public String RoomId { get; set; }
        public String DeptCode { get; set; }
        public String TypeCode { get; set; }
        public String DoctorCode { get; set; }
    }
    public class ExternalResDoctorState : ExternalResBase
    {
        public String DoctorState { get; set; }
        public String LoginState { get; set; }
    }
}
