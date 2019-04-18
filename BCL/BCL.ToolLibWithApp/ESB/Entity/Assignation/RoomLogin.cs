using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqRoomLogin : ExternalReqBase
    {
        public String RoomId { get; set; }
        public String TypeCode { get; set; }
        public String DeptCode { get; set; }
        public String DoctorCode { get; set; }
        public String DoctorPwd { get; set; }
    }
    public class ExternalResRoomLogin : ExternalResBase
    {
        public string DoctorCode { get; set; }
        public string DoctorName { get; set; }
    }
}
