using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Inspection
{
    public class ExternalReqInspectionResultQuery : ExternalReqBase
    {
        public String PatientId { get; set; }
        public String InspectionResultId { get; set; }
        public String BeginDateTime { get; set; }
        public String EndDateTime { get; set; }
    }

    public class ExternalResInspectionResultQuery : ExternalResBase
    {
        public String PatientId { get; set; }
        public List<InspecInfo> InspecList { get; set; }
        public ExternalResInspectionResultQuery()
        {
            InspecList = new List<InspecInfo>();
        }
    }
    public class InspecInfo
    {
        public String InspectionResultId { get; set; }
        public String InspectionName { get; set; }
        public String SerialNo { get; set; }
        public String TestState { get; set; }
        public String BillDate { get; set; }
        public String BillDeptCode { get; set; }
        public String BillDeptName { get; set; }
        public String BillDoctorCode { get; set; }
        public String BillDoctorName { get; set; }
        public String TestDeptCode { get; set; }
        public String TestDeptName { get; set; }
        public String TestDoctorCode { get; set; }
        public String TestDoctorName { get; set; }
        public String SampleNo { get; set; }
        public String SampleTypeCode { get; set; }
        public String SampleTypeName { get; set; }
        public String TestMethodCode { get; set; }
        public String TestMethodName { get; set; }
        public String ReportDate { get; set; }
        public List<InspecResultInfo> InspecResultList { get; set; }
        public InspecInfo()
        {
            InspecResultList = new List<InspecResultInfo>();
        }
    }
    public class InspecResultInfo
    {
        /// <summary>
        /// 试验项目代码
        /// </summary>
        public String TestItemCode { get; set; }
        /// <summary>
        /// 试验项目名称
        /// </summary>
        public String TestItemName { get; set; }
        /// <summary>
        /// 试验日期
        /// </summary>
        public String TestDate { get; set; }
        /// <summary>
        /// 试验结果(定性)
        /// </summary>
        public String TestResultQ { get; set; }
        /// <summary>
        /// 试验结果(数值)
        /// </summary>
        public String TestResultN { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public String Unit { get; set; }
        /// <summary>
        /// 参考范围
        /// </summary>
        public String ReferenceRange { get; set; }
        /// <summary>
        /// 试验指标
        /// </summary>
        public String TestTarget { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public String DispayNum { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }
    }
}
