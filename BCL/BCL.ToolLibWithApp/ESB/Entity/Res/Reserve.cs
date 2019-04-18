using BCL.ToolLibWithApp.ESB.Entity.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Res
{
    /// <summary>
    /// 预约请求参数
    /// </summary>
    public class ExternalReqReserve : ExternalReqBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string PaperWorkType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string PaperWorkNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 周排班Id
        /// </summary>
        public string WeekId { get; set; }

        /// <summary>
        /// 日排班Id
        /// </summary>
        public string DayId { get; set; }

        /// <summary>
        /// 排班班次
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 预约日期
        /// </summary>
        public string ResDate { get; set; }

        /// <summary>
        /// 号源序号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 就诊时间
        /// </summary>
        public string VisitTime { get; set; }

        /// <summary>
        /// 预约渠道
        /// </summary>
        public string ResChannel { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>
        public string MobilePhoneNo { get; set; }
    }

    /// <summary>
    /// 预约响应
    /// </summary>
    public class ExternalResReserve : ExternalResBase
    {
        public ResInfo ResInfo { get; set; }
        public ExternalResReserve()
        {
            ResInfo = new ResInfo();
        }
    }
    /// <summary>
    /// 预约明细
    /// </summary>
    public class ResInfo
    {

        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 预约Id
        /// </summary>
        public string ResId { get; set; }

        /// <summary>
        /// 预约日期
        /// </summary>
        public string ResDate { get; set; }

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
        /// 医生姓名
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
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 就诊时间
        /// </summary>
        public string VisitTime { get; set; }

        /// <summary>
        /// 患者信息
        /// </summary>
        public PatientInfo PatientInfo { get; set; }

        /// <summary>
        /// 挂号金额
        /// </summary>
        public string RegAmount { get; set; }

        /// <summary>
        /// 预约状态
        /// </summary>
        public string ResState { get; set; }

        /// <summary>
        /// 排班类别代码
        /// </summary>
        public string TypeCode { get; set; }

        /// <summary>
        /// 周排班Id
        /// </summary>
        public string WeekId { get; set; }
        /// <summary>
        /// 预约状态说明
        /// </summary>
        public string ResStateMessage { get; set; }
        //卡号
        public string CardNum { get;set; }

        //金额
        public string TotalAmount { get; set; }
    }
}
