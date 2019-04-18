using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Patient
{
    public class ExternalReqPatientInformationDel : ExternalReqBase
    {
        public string PatientId { get; set; }
    }

    /*
    * 患者信息删除
    */
    public class ExternalResPatientInformationDel : ExternalResBase
    {

    }
}
