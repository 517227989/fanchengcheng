using System.Collections.Generic;

namespace BCL.ToolLibWithApp.ESB.Entity.ExaminationReport
{
    public class ExternalReqExamReportDiagnosisQuery : ExternalReqBase
    {
        public string ReportId { get; set; }
    }

    public class ExternalResExamReportDiagnosisQuery : ExternalResBase
    {
        public List<ExternalExamReportDiagnosis> ExamReportDiagnoses { get; set; }
    }

    public class ExternalExamReportDiagnosis
    {
        /// <summary>
        /// 诊断建议
        /// </summary>
        public string Suggestion { get; set; }
        /// <summary>
        /// 诊断时间
        /// </summary>
        public string DiagnosisTime { get; set; }
    }
}
