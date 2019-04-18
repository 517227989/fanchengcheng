using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BCL.ToolLibWithApp.MIP.Models.V1
{
    [XmlRoot("Root")]
    public class BngBillModel : BngBaseModel
    {

    }
    [XmlRoot("Root")]
    public class EndBillModel : EndBaseModel
    {
        public EndBillModel()
        {
            MediFund = new MediFund();
            MediDetailList = new List<MediDetail>();
        }
        /// <summary>
        /// 医保交易流水号
        /// </summary>
        public string MediNo { get; set; }
        /// <summary>
        /// 医保交易日期
        /// </summary>
        public string MediDate { get; set; }
        /// <summary>
        /// 商户Code
        /// </summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 支付订单号
        /// </summary>
        public string ReqNo { get; set; }
        /// <summary>
        /// 支付二维码
        /// </summary>
        public string OrderInfo { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string Mode { get; set; }
        /// <summary>
        /// 支付流水号
        /// </summary>
        public string ResNo { get; set; }
        /// <summary>
        /// 支付日期
        /// </summary>
        public string ResDate { get; set; }
        /// <summary>
        /// ICD代码
        /// </summary>
        public string ICDCode { get; set; }
        /// <summary>
        /// ICD名称
        /// </summary>
        public string ICDName { get; set; }
        /// <summary>
        /// 基金详情
        /// </summary>
        [XmlElement("Funds")]
        public MediFund MediFund { get; set; }
        /// <summary>
        /// 医保明细
        /// </summary>
        [XmlArray("Details"), XmlArrayItem("Detail")]
        public List<MediDetail> MediDetailList { get; set; }
    }
    public class MediFund
    {
        public string TAmount { get; set; }
        public string CAmount { get; set; }
        public string RAmount { get; set; }
        public string TYAmount { get; set; }
        public string OYAmount { get; set; }
        public string OFAmount { get; set; }
        public string TEAmount { get; set; }
        public string TSAmount { get; set; }
        public string TCAmount { get; set; }
        public string PEAmount { get; set; }
        public string PSAmount { get; set; }
        public string PCAmount { get; set; }
        public string Amount1 { get; set; }
        public string Amount2 { get; set; }
        public string Amount3 { get; set; }
        public string Amount4 { get; set; }
        public string Amount5 { get; set; }
        public string Amount6 { get; set; }
        public string Amount7 { get; set; }
        public string Amount8 { get; set; }
        public string Amount9 { get; set; }
        public string Amount10 { get; set; }
        public string Amount11 { get; set; }
        public string Amount12 { get; set; }
        public string Amount13 { get; set; }
        public string Amount14 { get; set; }
        public string Amount15 { get; set; }
        public string Amount16 { get; set; }
        public string Amount17 { get; set; }
        public string Amount18 { get; set; }
        public string Amount19 { get; set; }
        public string Amount20 { get; set; }
        public string Amount21 { get; set; }
        public string Amount22 { get; set; }
        public string Amount23 { get; set; }
        public string PICCAmt { get; set; }
        public string PICCInfo { get; set; }
        public string DrugWindow { get; set; }
        public string InsurKind { get; set; }
        public string DistrctCode { get; set; }
        public string BillChannel { get; set; }
        public string DoctorCode { get; set; }
        public string TreatType { get; set; }
        public string MediResMsg { get; set; }
    }
    public class MediDetail
    {
        public string ReceiptId { get; set; }
        public string ReceiptType { get; set; }
        public string ItemCode { get; set; }
        public string ItemPlaceCode { get; set; }
        public string ItemName { get; set; }
        public string BillDate { get; set; }
        public string MediCode { get; set; }
        public string ItemPayRTatio { get; set; }
    }
}
