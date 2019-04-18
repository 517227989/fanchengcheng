using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.InHospital
{
    public class ExternalReqInHospitalDepositConfirm: ExternalReqBase
    {
        public ExternalReqInHospitalDepositConfirm()
        {
            RefundList = new DepositInfo();
        }
        public string PatientId { get; set; }
        public string InHospitalId { get; set; }

        public DepositInfo RefundList { get; set; }
    }

    public class ExternalResInHospitalDepositConfirm: ExternalResBase
    {
        public ExternalResInHospitalDepositConfirm() { }
    }
}
