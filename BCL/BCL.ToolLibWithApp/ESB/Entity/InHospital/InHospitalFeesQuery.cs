using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.InHospital
{
    /// <summary>
    /// 住院费用查询
    /// </summary>
    public class ExternalReqInHospitalFeesQuery : ExternalReqBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 住院Id
        /// </summary>
        public string InHospitalId { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public string BeginDateTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDateTime { get; set; }

        /// <summary>
        /// 校验密码
        /// </summary>
        public string VerifyCode { get; set; }
    }

    /// <summary>
    /// 住院费用查询
    /// </summary>
    public class ExternalResInHospitalFeesQuery : ExternalResBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 住院Id
        /// </summary>
        public string InHospitalId { get; set; }

        /// <summary>
        /// 汇总清单
        /// </summary>
        public List<SummaryInfo> SummaryList { get; set; }

        /// <summary>
        /// 每日清单
        /// </summary>
        public List<DailyInfo> DailyList { get; set; }
        public ExternalResInHospitalFeesQuery()
        {
            SummaryList = new List<SummaryInfo>();
            DailyList = new List<DailyInfo>();
        }
    }
    public class SummaryInfo
    {

        /// <summary>
        /// 项目归类代码
        /// </summary>
        public string ItemClassifyCode { get; set; }

        /// <summary>
        /// 项目归类名称
        /// </summary>
        public string ItemClassifyName { get; set; }

        /// <summary>
        /// 项目归类金额
        /// </summary>
        public string ItemClassifyFee { get; set; }

        /// <summary>
        /// 诊断顺序
        /// </summary>
        public string DiseaseOrder { get; set; }
    }

    public class DailyInfo
    {
        /// <summary>
        /// 费用日期
        /// </summary>
        public string FeeDate { get; set; }
        /// <summary>
        /// 每日金额
        /// </summary>
        public string DailyAmount { get; set; }
        /// <summary>
        /// 费用明细
        /// </summary>
        public List<FeeInfo> FeeList { get; set; }
        public DailyInfo()
        {
            FeeList = new List<FeeInfo>();
        }
    }

    public class FeeInfo
    {

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
        /// 规格
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 计费日期
        /// </summary>
        public string BillDate { get; set; }
    }
}
