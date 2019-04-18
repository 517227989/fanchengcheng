using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Patient
{
    /// <summary>
    /// 患者信息查询
    /// </summary>
    public class ExternalReqPatientInformation : ExternalReqBase
    {
        public ExternalReqPatientInformation()
        {
            AcquisitionMode = "0";
        }
        /// <summary>
        /// 病历本封皮费用
        /// </summary>
        public string CaseFee { get; set; }
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 卡类型
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 卡内信息
        /// </summary>
        public string CardInfo { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }
        /// <summary>
        /// 获取方式 默认0 HIS
        /// </summary>
        public string AcquisitionMode { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string AcquisitionValue { get; set; }
        /// <summary>
        /// 接收参数
        /// </summary>
        public string ReceiveParams { get; set; }
        public string EMPI { get; set; }
    }

    /*
    * 患者信息查询
    */

    public class ExternalResPatientInformation : ExternalResBase
    {
        public List<PatientInfo> PatientList { get; set; }

        public ExternalResPatientInformation()
        {
            PatientList = new List<PatientInfo>();
        }
    }

    /*
     * 患者明细
     */

    public class PatientInfo
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 病人类型
        /// </summary>
        public string PatientType { get; set; }

        /// <summary>
        /// 病人类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 病人性质
        /// </summary>
        public string Nature { get; set; }

        /// <summary>
        /// 病人性质名称
        /// </summary>
        public string NatureName { get; set; }

        /// <summary>
        /// 病人就诊卡号
        /// </summary>
        public string VisitCardNo { get; set; }

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 病人性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// 病人证件类型
        /// </summary>
        public string PaperWorkType { get; set; }

        /// <summary>
        /// 病人证件号码
        /// </summary>
        public string PaperWorkNo { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 病人移动电话
        /// </summary>
        public string MobilePhoneNo { get; set; }

        /// <summary>
        /// 病人家庭地址
        /// </summary>
        public string HomeAddress { get; set; }

        /// <summary>
        /// 病人家庭电话
        /// </summary>
        public string HomePhoneNo { get; set; }

        /// <summary>
        /// 病人工作单位
        /// </summary>
        public string WorkAddress { get; set; }

        /// <summary>
        /// 病人工作电话
        /// </summary>
        public string WorkPhoneNo { get; set; }
        /// <summary>
        /// 计收卡费标志
        /// </summary>
        public string CardFee { get; set; }
        /// <summary>
        /// 监护人姓名
        /// </summary>
        public string GuardianName { get; set; }
        /// <summary>
        /// 监护人联系电话
        /// </summary>
        public string GuardianPhoneNo { get; set; }
        /// <summary>
        /// 监护人身份证号
        /// </summary>
        public string GuardianIdCardNo { get; set; }
        /// <summary>
        /// 默认 0
        /// 0、HIS
        /// 1、电子健康卡
        /// </summary>
        public string AddMode { get; set; }
        /// <summary>
        /// 病人绑定账户信息
        /// </summary>
        public BindingAccInfo BindAccInfo { get; set; }

        /// <summary>
        /// 病人医保账户信息
        /// </summary>
        public MedicareAccInfo MediAccInfo { get; set; }

        /// <summary>
        /// 回传参数
        /// </summary>
        public string BackParams { get; set; }
        /// <summary>
        /// 患者主索引
        /// </summary>
        public string EMPI { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        public PatientInfo()
        {
            BindAccInfo = new BindingAccInfo();
            MediAccInfo = new MedicareAccInfo();
        }
    }

    /*
    * 绑定账户
    */

    public class BindingAccInfo
    {
        /// <summary>
        /// 账户状态
        /// </summary>
        public string AccState { get; set; }

        /// <summary>
        /// 账户号码
        /// </summary>
        public string AccNo { get; set; }

        /// <summary>
        /// 账户名称
        /// </summary>
        public string AccName { get; set; }

        /// <summary>
        /// 账户余额
        /// </summary>
        public string AccBalance { get; set; }
    }

    /*
    * 医保账户
    */

    public class MedicareAccInfo
    {
        /// <summary>
        /// 个人编号
        /// </summary>
        public string PersonNo { get; set; }

        /// <summary>
        /// 医保卡号
        /// </summary>
        public string MediCardNo { get; set; }

        /// <summary>
        /// 医保卡识别码
        /// </summary>
        public string MediCardIdentifier { get; set; }

        /// <summary>
        /// 医保卡信息串
        /// </summary>
        public string MedicalCardInfo { get; set; }

        /// <summary>
        /// 医保患者信息
        /// </summary>
        public string MediPersonInfo { get; set; }

        /// <summary>
        /// 本年账户余额
        /// </summary>
        public string ThisYearAccBalance { get; set; }

        /// <summary>
        /// 历年账户余额
        /// </summary>
        public string OverYearAccBalance { get; set; }
    }

    /// <summary>
    /// 患者常用科室(中医院提出,2019-04-08添加)
    /// </summary>
    public class ExternalReqPatientCommonDepts : ExternalReqBase
    {
        public string PatientId { get; set; }
    }

    public class ExternalResPatientCommonDepts : ExternalResBase
    {
        public List<CommonDepts> DeptList { get; set; }

        public ExternalResPatientCommonDepts()
        {
            DeptList = new List<CommonDepts>();
        }
    }

    public class CommonDepts
    {
        public string jzkh { get; set; }

        public string brxm { get; set; }

        public string ksdm { get; set; }

        public string ksmc { get; set; }

        public string cs { get; set; }

    }
}
