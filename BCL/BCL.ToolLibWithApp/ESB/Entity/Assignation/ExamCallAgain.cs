using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqExamCallAgain : ExternalReqBase
    {
        public String DeptCode { get; set; }
        public String DoctorCode { get; set; }
        public String DistrictId { get; set; }
        public String RoomId { get; set; }
    }
    public class ExternalResExamCallAgain : ExternalResBase
    {
        public String Number { get; set; }
    }
}
