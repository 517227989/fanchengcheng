using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Examination
{
    public class ExternalReqExamResultQuery : ExternalReqBase
    {
        public String PatientId { get; set; }
        public String ExamResultId { get; set; }
        public String BeginDateTime { get; set; }
        public String EndDateTime { get; set; }
    }

    public class ExternalResExamResultQuery : ExternalResBase
    {
        public String PatientId { get; set; }
        public List<ExamInfo> ExamList { get; set; }
        public ExternalResExamResultQuery()
        {
            ExamList = new List<ExamInfo>();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ExamInfo
    {
        /// <summary>
        /// 检查结果Id
        /// </summary>
        public String ExamResultId { get; set; }
        /// <summary>
        /// 检查名称
        /// </summary>
        public String ExamName { get; set; }
        /// <summary>
        /// 检查项目代码
        /// </summary>
        public String CheckItemCode { get; set; }
        /// <summary>
        /// 检查项目名称
        /// </summary>
        public String CheckItemName { get; set; }
        /// <summary>
        /// 检查日期
        /// </summary>
        public String CheckDate { get; set; }
        /// <summary>
        /// 开单医生代码
        /// </summary>
        public String BillDoctorCode { get; set; }
        /// <summary>
        /// 开单医生名称
        /// </summary>
        public String BillDoctorName { get; set; }
        /// <summary>
        /// 开单日期
        /// </summary>
        public String BillDate { get; set; }
        /// <summary>
        /// 审核医生代码
        /// </summary>
        public String VerifyDoctorCode { get; set; }
        /// <summary>
        /// 审核医生名称
        /// </summary>
        public String VerifyDoctorName { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public String VerifyDate { get; set; }
        /// <summary>
        /// 检查状态
        /// 1.已出报告
        /// 2.未出报告
        /// </summary>
        public String CheckState { get; set; }
        /// <summary>
        /// 开单科室代码
        /// </summary>
        public String BillDeptCode { get; set; }
        /// <summary>
        /// 开单科室名称
        /// </summary>
        public String BillDeptName { get; set; }
        /// <summary>
        /// 检查科室代码
        /// </summary>
        public String CheckDeptCode { get; set; }
        /// <summary>
        /// 检查科室名称
        /// </summary>
        public String CheckDeptName { get; set; }
        /// <summary>
        /// 检查医生代码
        /// </summary>
        public String CheckDoctorCode { get; set; }
        /// <summary>
        /// 检查医生名称
        /// </summary>
        public String CheckDoctorName { get; set; }
        /// <summary>
        /// 出报告时间
        /// </summary>
        public String ReportDate { get; set; }
        /// <summary>
        /// 总结
        /// </summary>
        public String Conclusion { get; set; }
        public List<ExamResultInfo> ExamResultList { get; set; }
        public ExamInfo()
        {
            ExamResultList = new List<ExamResultInfo>();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ExamResultInfo
    {
        /// <summary>
        /// 检查描述
        /// </summary>
        public String CheckDescription { get; set; }
        /// <summary>
        /// 检查结果
        /// </summary>
        public String CheckResult { get; set; }
        /// <summary>
        /// 检查部位
        /// </summary>
        public String CheckPlace { get; set; }
    }
}
