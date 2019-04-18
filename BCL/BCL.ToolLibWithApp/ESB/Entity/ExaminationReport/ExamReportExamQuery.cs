using System.Collections.Generic;

namespace BCL.ToolLibWithApp.ESB.Entity.ExaminationReport
{
    public class ExternalReqExamReportExamQuery : ExternalReqBase
    {
        public string ReportId { get; set; }
    }

    public class ExternalResExamReportExamQuery : ExternalResBase
    {
        public List<ExternalExamReportExam> ExamReportExams { get; set; }
    }

    public class ExternalExamReportExam
    {
        /// <summary>
        /// 检查名称
        /// </summary>
        public string ExamName { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 正常范围
        /// </summary>
        public string Range { get; set; }
        /// <summary>
        /// 检查结果
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 提示
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 医生名称
        /// </summary>
        public string DoctorName { get; set; }
        /// <summary>
        /// 检查时间
        /// </summary>
        public string ExamTime { get; set; }
    }
}
