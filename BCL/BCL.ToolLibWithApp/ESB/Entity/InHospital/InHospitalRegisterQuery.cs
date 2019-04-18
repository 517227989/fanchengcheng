using BCL.ToolLibWithApp.ESB.Entity.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.InHospital
{
    /*
     * 住院登记查询
     */

    public class ExternalReqInHospitalRegisterQuery : ExternalReqBase
    {

        /// <summary>
        /// 患者Id
        public string PatientId { get; set; }

        /// <summary>
        /// 病区代码
        /// </summary>
        public string WardCode { get; set; }

        /// <summary>
        /// 床位代码
        /// </summary>
        public string BedCode { get; set; }

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
        /// 病案号
        /// </summary>
        public string RecordNo { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }

        public string Name { get; set; }
        /// <summary>
        /// 住院状态
        /// </summary>
        public string HospitalState { get; set; }


    }
    /// <summary>
    /// 住院登记查询
    /// </summary>
    public class ExternalResInHospitalRegisterQuery : ExternalResBase
    {
        public List<InHosRegInfo> InHosRegList { get; set; }
        public ExternalResInHospitalRegisterQuery()
        {
            InHosRegList = new List<InHosRegInfo>();
        }
    }

    public class InHosRegInfo
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
        /// 年龄
        /// </summary>
        public string Age { get; set; }

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
        /// 家庭地址
        /// </summary>
        public string HomeAddress { get; set; }

        /// <summary>
        /// 家庭电话
        /// </summary>
        public string HomePhoneNo { get; set; }

        /// <summary>
        /// 工作地址
        /// </summary>
        public string WorkAddress { get; set; }

        /// <summary>
        /// 工作电话
        /// </summary>
        public string WorkPhoneNo { get; set; }

        /// <summary>
        /// 入院科室代码
        /// </summary>
        public string AdmissDeptCode { get; set; }

        /// <summary>
        /// 入院科室名称
        /// </summary>
        public string AdmissDeptName { get; set; }

        /// <summary>
        /// 主治医生代码
        /// </summary>
        public string DoctorCode { get; set; }

        /// <summary>
        /// 主治医生名称
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 病区代码
        /// </summary>
        public string WardCode { get; set; }

        /// <summary>
        /// 病区名称
        /// </summary>
        public string WardName { get; set; }

        /// <summary>
        /// 床位代码
        /// </summary>
        public string BedCode { get; set; }

        /// <summary>
        /// 床位名称
        /// </summary>
        public string BedName { get; set; }

        /// <summary>
        /// 在院状态
        /// </summary>
        public string HospitalState { get; set; }

        /// <summary>
        /// 入院日期
        /// </summary>
        public string AdmissDate { get; set; }

        /// <summary>
        /// 出院日期
        /// </summary>
        public string DischargeDate { get; set; }

        /// <summary>
        /// 住院费用总额
        /// </summary>
        public string TotalFee { get; set; }

        /// <summary>
        /// 自费金额
        /// </summary>
        public string SelfPayFee { get; set; }

        /// <summary>
        /// 预交款余额
        /// </summary>
        public string Balance { get; set; }

        /// <summary>
        /// 病案号
        /// </summary>
        public string RecordNo { get; set; }

        /// <summary>
        /// 绑定账户信息
        /// </summary>
        public BindingAccInfo BindAccInfo { get; set; }

        /// <summary>
        /// 医保账户信息
        /// </summary>
        public MedicareAccInfo MediAccInfo { get; set; }

        /// <summary>
        /// 诊断明细
        /// </summary>
        public List<DiseaseInfo> DiseaseList { get; set; }

        /// <summary>
        /// 预交款总额
        /// </summary>
        public string BalanceTotal { get; set; }

        /// <summary>
        /// 是否可自助机结算标志
        /// </summary>
        public string IsCanUseKiosk { get; set; }

        /// <summary>
        /// 是否医保用户
        /// </summary>
        public string IsMedicalPatient { get; set; }

        //初始化对象
        public InHosRegInfo()
        {
            MediAccInfo = new MedicareAccInfo();
            BindAccInfo = new BindingAccInfo();
            DiseaseList = new List<DiseaseInfo>();
        }
    }

    public class DiseaseInfo
    {

        /// <summary>
        /// 诊断代码
        /// </summary>
        public string DiseaseCode { get; set; }

        /// <summary>
        /// 诊断名称
        /// </summary>
        public string DiseaseName { get; set; }

        /// <summary>
        /// 诊断类型
        /// </summary>
        public string DiseaseType { get; set; }

        /// <summary>
        /// 诊断顺序
        /// </summary>
        public string DiseaseOrder { get; set; }
    }
}
