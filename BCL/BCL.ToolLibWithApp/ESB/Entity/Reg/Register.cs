using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Reg
{
    /// <summary>
    /// 挂号
    /// </summary>
    public class ExternalReqRegister : ExternalReqBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 日排班Id
        /// </summary>
        public string DayId { get; set; }

        /// <summary>
        /// 号源号码
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 就诊时间 
        /// </summary>
        public string VisitTime { get; set; }

        /// <summary>
        /// 排班班次
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 挂号渠道
        /// </summary>
        public string RegChannel { get; set; }
        /// <summary>
        /// 是否支付
        /// </summary>
        public string IsPay { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCardNo { get; set; }
        public string CardType { get; set; }
    }

    public class ExternalResRegister : ExternalResBase
    {
        public RegInfo RegInfo { get; set; }
        public ExternalResRegister()
        {
            RegInfo = new RegInfo();
        }
    }

    public class RegInfo
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 挂号Id
        /// </summary>
        public string RegId { get; set; }
        /// <summary>
        /// 挂号日期
        /// </summary>
        public string RegDate { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 医生代码
        /// </summary>
        public string DoctorCode { get; set; }
        /// <summary>
        /// 医生名称
        /// </summary>
        public string DoctorName { get; set; }
        /// <summary>
        /// 上下午
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 挂号序号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 就诊时间
        /// </summary>
        public string VisitTime { get; set; }

        /// <summary>
        /// 就诊地点
        /// </summary>
        public string VisitAddr { get; set; }

        public string BackParams { get; set; }

        /// <summary>
        /// 挂号支付
        /// </summary>
        public RegPay RegPay { get; set; }

        /// <summary>
        /// 挂号详细信息
        /// </summary>
        public RegDetail RegDetail { get; set; }
        /// <summary>
        /// 是否支付 0 支付 1不支付
        /// </summary>
        public string IsPay { get; set; }
        public RegInfo()
        {
            RegPay = new RegPay();
            RegDetail = new RegDetail();
        }
    }

    public class RegPay
    {
        /// <summary>
        /// 挂号金额
        /// </summary>
        public string RegAmount { get; set; }

        /// <summary>
        /// 报销金额
        /// </summary>
        public string MediApplyAmount { get; set; }

        /// <summary>
        /// 现金金额
        /// </summary>
        public string MediCashAmount { get; set; }

        /// <summary>
        /// 医保支付详情
        /// </summary>
        public MediPayDetail MediPayDetail { get; set; }

        /// <summary>
        /// 结算Id
        /// </summary>
        public string BillId { get; set; }
        public RegPay()
        {
            MediPayDetail = new MediPayDetail();
        }
    }

    public class MediPayDetail
    {
        /// <summary>
        /// 本年账户支付
        /// </summary>
        public string ThisYearAccPay { get; set; }

        /// <summary>
        /// 历年账户支付
        /// </summary>
        public string OverYearAccPay { get; set; }

        /// <summary>
        /// 本年账户余额
        /// </summary>
        public string ThisYearAccBalance { get; set; }

        /// <summary>
        /// 历年账户余额
        /// </summary>
        public string OverYearAccBalance { get; set; }

        /// <summary>
        /// 自理金额
        /// </summary>
        public string ProOneSelfAmount { get; set; }

        /// <summary>
        /// 自费金额
        /// </summary>
        public string OwnPayAmount { get; set; }

        /// <summary>
        /// 自负金额
        /// </summary>
        public string ResponsibleAmount { get; set; }
    }

    public class RegDetail
    {
        /// <summary>
        /// 患者类型
        /// </summary>
        public string PatientType { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 性质代码
        /// </summary>
        public string NatureCode { get; set; }

        /// <summary>
        /// 性质名称
        /// </summary>
        public string NatureName { get; set; }

        /// <summary>
        /// 就诊卡号
        /// </summary>
        public string VisitCardNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string PaperWorkType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string PaperWorkNo { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>
        public string MobilePhoneNo { get; set; }

        /// <summary>
        /// 挂号状态
        /// </summary>
        public string RegState { get; set; }
    }
}
