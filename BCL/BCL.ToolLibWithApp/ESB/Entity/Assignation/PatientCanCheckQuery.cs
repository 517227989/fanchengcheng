using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqPatientCanCheckQuery : ExternalReqBase
    {
        public String CardType { get; set; }
        public String CardNo { get; set; }
        public String NStationId { get; set; }
    }
    public class ExternalResPatientCanCheckQuery : ExternalResBase
    {
        public List<PatientCanCheckInfo> PatientCanCheckList { get; set; }
    }
    public class PatientCanCheckInfo
    {
        public String DeptCode { get; set; }
        public String DeptName { get; set; }
        public String DoctorCode { get; set; }
        public String DoctorName { get; set; }
        public String Name { get; set; }
        public String PatientId { get; set; }
        public String Number { get; set; }
        public List<RoomInfo> RoomList { get; set; }
    }
    public class RoomInfo
    {
        public String RoomId { get; set; }
        public String RoomName { get; set; }
        public String DoctorCode { get; set; }
        public String DoctorName { get; set; }
        public String CurrNo { get; set; }
        public String CheckedCout { get; set; }
        public String RoomState { get; set; }
        public String FirstVisitState { get; set; }
        public string FrontNum { get; set; }
    }
}
