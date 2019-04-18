using System.Collections.Generic;

namespace BCL.ToolLibWithApp.ESB.Entity.ExaminationReport
{
    public class ExternalReqExamReportHomepageQuery : ExternalReqBase
    {
        public string ReportId { get; set; }
    }
    public class ExternalResExamReportHomepageQuery : ExternalResBase
    {
        public List<ExternalExamReportHomepage> ExamReportHomepages { get; set; }
    }

    public class ExternalExamReportHomepage : ExternalExamReport
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public string VerifyDate { get; set; }
    }
}
