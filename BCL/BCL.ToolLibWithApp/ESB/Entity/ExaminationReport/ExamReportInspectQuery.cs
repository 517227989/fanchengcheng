using System.Collections.Generic;

namespace BCL.ToolLibWithApp.ESB.Entity.ExaminationReport
{
    public class ExternalReqExamReportInspectQuery : ExternalReqBase
    {
        public string ReportId { get; set; }
    }

    public class ExternalResExamReportInspectQuery : ExternalResBase
    {
        public List<ExternalExamReportInspect> ExamReportInspects { get; set; }
    }

    public class ExternalExamReportInspect
    {
        /// <summary>
        /// 检验名称
        /// </summary>
        public string InspectName { get; set; }
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
        /// 检验结果
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
        /// 检验时间
        /// </summary>
        public string InspectTime { get; set; }
    }
}
