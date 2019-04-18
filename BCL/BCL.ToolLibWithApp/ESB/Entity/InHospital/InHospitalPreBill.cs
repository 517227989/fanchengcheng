using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.InHospital
{
    public class ExternalReqInHospitalPreBill : ExternalReqBase
    {
        public string PatientId { get; set; }
        public string InHospitalId { get; set; }
    }

    public class ExternalResInHospitalPreBill : ExternalResBase
    {
        public ExternalResInHospitalPreBill()
        {
            DepositDetail = new List<DepositDetail>();
        }
        public string DepositAmount { get; set; }
        public string DepositBalance { get; set; }
        public List<DepositDetail> DepositDetail { get; set; }
    }
}
