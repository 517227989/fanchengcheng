using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.OutPatient
{
    /*
     * 门诊费用明细
     */

    public class ExternalReqOutPatientChargePay : ExternalReqBase
    {

        public string PatientId { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCardNo { get; set; }
        public List<ChargeInfo> ChargeList { get; set; }
        public ChargePayDetail ChargePayDetail { get; set; }
        public ExternalReqOutPatientChargePay()
        {
            ChargeList = new List<ChargeInfo>();
            ChargePayDetail = new ChargePayDetail();
        }
    }
    public class ChargePayDetail
    {
        public string BillId { get; set; }
        public string PayChannel { get; set; }
        public string PayId { get; set; }
        public string PayAmount { get; set; }
        public string PayDateTime { get; set; }
    }

    /*
     * 门诊费用明细
     */

    public class ExternalResOutPatientChargePay : ExternalResBase
    {
        public string BillId { get; set; }
        public string GuideInfo { get; set; }
        public ChargeDetail ChargeDetail { get; set; }
        public ExternalResOutPatientChargePay()
        {
            ChargeDetail = new ChargeDetail();
        }
    }

    /*
    * 费用信息
    */
    public class ChargeDetail
    {
        public string ChargeDate { get; set; }
        public string TotalAmount { get; set; }
        public string ApplyAmount { get; set; }
        public string CashAmount { get; set; }
        public DiscountDetial DiscountDetial { get; set; }
        public MediPayDetail MediPayDetail { get; set; }
        public ChargeDetail()
        {
            DiscountDetial = new DiscountDetial();
            MediPayDetail = new MediPayDetail();
        }
    }
    public class DiscountDetial
    {

    }
    public class MediPayDetail
    {
        public string ThisYearAccPay { get; set; }
        public string OverYearAccPay { get; set; }
        public string ThisYearAccBalance { get; set; }
        public string OverYearAccBalance { get; set; }
        public string ProOneSelfAmount { get; set; }
        public string OwnPayAmount { get; set; }
        public string ResponsibleAmount { get; set; }

    }
}
