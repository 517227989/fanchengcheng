using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.InHospital
{
    public class ExternalReqInHospitalBill : ExternalReqBase
    {
        public ExternalReqInHospitalBill()
        {
            RefundList = new DepositDetail();
        }
        public string PatientId { get; set; }
        public string InHospitalId { get; set; }

        public DepositDetail RefundList { get; set; }
    }

    public class ExternalResInHospitalBill : ExternalResBase
    {
        public string BillId { get; set; }
        public string TotalFee { get; set; }
        public string MediFee { get; set; }
    }
}
