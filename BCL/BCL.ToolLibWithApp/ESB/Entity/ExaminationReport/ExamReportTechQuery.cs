using System.Collections.Generic;

namespace BCL.ToolLibWithApp.ESB.Entity.ExaminationReport
{
    public class ExternalReqExamReportTechQuery : ExternalReqBase
    {
        public string ReportId { get; set; }
    }

    public class ExternalResExamReportTechQuery : ExternalResBase
    {
        public List<ExternalExamReportTech> ExternalExamReportTeches { get; set; }
    }

    public class ExternalExamReportTech
    {
        /// <summary>
        /// 医技名称
        /// </summary>
        public string InspectName { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 检查结论
        /// </summary>
        public string Conclusion { get; set; }
        /// <summary>
        /// 检查结果
        /// </summary>
        public string Result { get; set; }
    }
}
