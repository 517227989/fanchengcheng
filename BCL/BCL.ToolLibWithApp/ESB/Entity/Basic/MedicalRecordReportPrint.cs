using System.Collections.Generic;

namespace BCL.ToolLibWithApp.ESB.Entity.Basic
{
    public class ExternalReqPathologicalReportPrint : ExternalReqBase
    {
        /// <summary>
        /// 病历号
        /// </summary>
        public string RecordNo { get; set; }
        /// <summary>
        /// 患者ID
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
    }

    public class ExternalResPathologicalReportPrint : ExternalResBase
    {
        public ExternalResPathologicalReportPrint()
        {
            _PathologicalRecordReportInfo = new List<PathologicalRecordReportInfo>();
        }
        public List<PathologicalRecordReportInfo> _PathologicalRecordReportInfo { get; set; }
    }

    public class PathologicalRecordReportInfo
    {
        /// <summary>
        /// 病历号
        /// </summary>
        public string RecordNo { get; set; }
        /// <summary>
        /// 患者ID
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
        /// 报告单号
        /// </summary>
        public string ReportId { get; set; }
        /// <summary>
        /// 状态，打印状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 打印内容,不可以为空
        /// </summary>
        public string PrintContent { get; set; }
        /// <summary>
        /// 打印类型，不可为空,必须与PrintContent一起用
        /// </summary>
        public string PrintType { get; set; }
    }
}
