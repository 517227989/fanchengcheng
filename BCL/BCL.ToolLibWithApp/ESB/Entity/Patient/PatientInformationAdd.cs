using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Patient
{
    /*
     * 患者信息增加
     */
    public class ExternalReqPatientInformationAdd : ExternalReqBase
    {
        /// <summary>
        /// 患者明细
        /// </summary>
        //public List<PatientInfo> PatientList { get; set; }
        public PatientInfo PatientInfo { get; set; }

        public ExternalReqPatientInformationAdd()
        {
            PatientInfo = new PatientInfo();
        }
    }

    /*
     * 患者信息增加
     */
    public class ExternalResPatientInformationAdd : ExternalResBase
    {
        public string PatientId { get; set; }
        public string VisitCardNo { get; set; }
        public string QRCode { get; set; }
        public string QRCodeImg { get; set; }
    }
}
