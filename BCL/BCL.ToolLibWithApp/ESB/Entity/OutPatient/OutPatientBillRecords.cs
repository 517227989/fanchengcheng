using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.OutPatient
{
    public class ExternalReqOutPatientBillRecords : ExternalReqBase
    {
        public string PatientId { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCardNo { get; set; }
        public string BillId { get; set; }
        public string BeginDateTime { get; set; }
        public string EndDateTime { get; set; }
    }

    public class ExternalResOutPatientBillRecords : ExternalResBase
    {
        public List<BillInfo> BillList { get; set; }
        public ExternalResOutPatientBillRecords()
        {
            BillList = new List<BillInfo>();
        }
    }
    public class BillInfo
    {
        public string BillId { get; set; }
        public ChargeDetail ChargeDetail { get; set; }
        public ChargePayDetail ChargePayDetail { get; set; }
        public List<ChargeInfo> ChargeList { get; set; }
        public BillInfo()
        {
            ChargeDetail = new ChargeDetail();
            ChargePayDetail = new ChargePayDetail();
            ChargeList = new List<ChargeInfo>();
        }
    }
}
