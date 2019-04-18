using System.Collections.Generic;

namespace BCL.ToolLibWithApp.ESB.Entity.ExaminationReport
{
    public class ExternalReqExamReportQuery : ExternalReqBase
    {
        public string IdCardNumber { get; set; }
    }

    public class ExternalResExamReportQuery : ExternalResBase
    {
        public List<ExternalExamReport> ExamReports { get; set; }
    }

    public class ExternalExamReport
    {
        /// <summary>
        /// 报告Id
        /// </summary>
        public string ReportId { get; set; }
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
        public string BirthDate { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNumber { get; set; }
        /// <summary>
        /// 体检日期
        /// </summary>
        public string ExamDate { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
