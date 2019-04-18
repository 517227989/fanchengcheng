using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqPatientReferralCheck : ExternalReqBase
    {
        public String BusinessId { get; set; }
        public String TypeCode { get; set; }
        public String DeptCode { get; set; }
        public String DoctorCode { get; set; }
        public String RoomId { get; set; }
        /// <summary>
        /// 1：医生暂停可报到 0：医生暂停不可报到  0:默认 
        /// </summary>
        [DefaultValue("0")]
        public string CoerceCheckFlag { get; set; }
    }
    public class ExternalResPatientReferralCheck : ExternalResPatientCheck
    {

    }
}
