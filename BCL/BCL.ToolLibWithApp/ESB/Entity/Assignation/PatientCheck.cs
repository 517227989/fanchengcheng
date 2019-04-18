using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqPatientCheck : ExternalReqBase
    {
        public String CardType { get; set; }
        public String CardInfo { get; set; }
        public String RoomId { get; set; }
        public String DoctorCode { get; set; }
        public String BusinessId { get; set; }
        public String NStationId { get; set; }
        /// <summary>
        /// 1：医生暂停可报到 0：医生暂停不可报到  0:默认 
        /// </summary>
        [DefaultValue("0")]
        public string CoerceCheckFlag { get; set; }
    }
    public class ExternalResPatientCheck : ExternalResBase
    {
        public CheckInfo CheckInfo { get; set; }
    }
    public class CheckInfo
    {
        public String Name { get; set; }
        public String Number { get; set; }
        public String RoomId { get; set; }
        public String QueueNo { get; set; }
        public String FrontNum { get; set; }
        public String RoomName { get; set; }
        public String PatientId { get; set; }
        public String CheckDeptCode { get; set; }
        public String CheckDeptName { get; set; }
        public String CheckDoctorCode { get; set; }
        public String CheckDoctorName { get; set; }
    }
}
