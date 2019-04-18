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

    public class ExternalReqOutPatientChargeDetails : ExternalReqBase
    {

        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCardNo { get; set; }
        /// <summary>
        /// 门诊类别
        /// </summary>
        public string VisitKind { get; set; }
        /// <summary>
        /// 业务内容
        /// </summary>
        public string Content { get; set; }
    }

    /*
     * 门诊费用明细
     */

    public class ExternalResOutPatientChargeDetails : ExternalResBase
    {
        public string TotalAmount { get; set; }
        public List<ChargeInfo> ChargeList { get; set; }
        public ExternalResOutPatientChargeDetails()
        {
            ChargeList = new List<ChargeInfo>();
        }
    }

    /*
    * 费用信息
    */
    public class ChargeInfo
    {
        /// <summary>
        /// 单据Id
        /// </summary>
        public string Receiptid { get; set; }
        /// <summary>
        /// 单据类型
        /// </summary>
        public string ReceiptType { get; set; }

        /// <summary>
        /// 单据名称
        /// </summary>
        public string ReceiptName { get; set; }

        /// <summary>
        /// 明细Id
        /// </summary>
        public string DetailId { get; set; }

        /// <summary>
        /// 项目代码
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 项目归类代码
        /// </summary>
        public string ItemClassifyCode { get; set; }

        /// <summary>
        /// 项目归类名称
        /// </summary>
        public string ItemClassifyName { get; set; }

        /// <summary>
        /// 项目产地代码
        /// </summary>
        public string ItemPlaceCode { get; set; }

        /// <summary>
        /// 项目产地名称
        /// </summary>
        public string ItemPlaceName { get; set; }

        /// <summary>
        /// 项目单价
        /// </summary>
        public string ItemPrice { get; set; }

        /// <summary>
        /// 项目数量
        /// </summary>
        public string ItemNum { get; set; }

        /// <summary>
        /// 项目金额
        /// </summary>
        public string ItemAmount { get; set; }

        /// <summary>
        /// 项目自付比例
        /// </summary>
        public string ItemPayRatio { get; set; }

        /// <summary>
        /// 自理自费金额
        /// </summary>
        public string OwnPayAmount { get; set; }

        /// <summary>
        /// 医保等级
        /// </summary>
        public string MediLevel { get; set; }

        /// <summary>
        /// 项目规格
        /// </summary>
        public string ItemFormat { get; set; }

        /// <summary>
        /// 项目单位
        /// </summary>
        public string ItemUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BillDate { get; set; }
        /// <summary>
        ///   开单科室代码
        /// </summary>
        public string BillDeptCode { get; set; }
        /// <summary>
        /// 开单科室名称
        /// </summary>
        public string BillDeptName { get; set; }
        /// <summary>
        /// 开单医生代码
        /// </summary>
        public string BillDoctorCode { get; set; }
        /// <summary>
        /// 开单医生名称
        /// </summary>
        public string BillDoctorName { get; set; }
        /// <summary>
        /// 就诊Id
        /// </summary>
        public string VisitId { get; set; }
        /// <summary>
        /// 结算Id
        /// </summary>
        public string BillId { get; set; }
        /// <summary>
        /// 执行科室代码
        /// </summary>
        public string ExecuteDeptCode { get; set; }
        /// <summary>
        /// 执行科室名称
        /// </summary>
        public string ExecuteDeptName { get; set; }
    }
}
