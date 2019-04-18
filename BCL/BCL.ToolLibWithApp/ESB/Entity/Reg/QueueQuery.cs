using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Reg
{
    /*
     * 队列查询
     */

    public class ExternalReqQueueQuery : ExternalReqBase
    {
        /// <summary>
        /// 队列类型
        /// </summary>
        public string QueueType { get; set; }

        /// <summary>
        /// 患者ID
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 队列代码
        /// </summary>
        public string QueueCode { get; set; }
    }

    /*
    * 队列查询
    */

    public class ExternalResQueueQuery : ExternalResBase
    {
        /// <summary>
        /// 就诊队列明细
        /// </summary>
        public List<VisitInfo> VisitList { get; set; }

        /// <summary>
        /// 检查队列明细
        /// </summary>
        public List<ExamInfo> ExamList { get; set; }

        /// <summary>
        /// 检验队列明细
        /// </summary>
        public List<InspectionInfo> InspectionList { get; set; }
        public ExternalResQueueQuery()
        {
            VisitList = new List<VisitInfo>();
            ExamList = new List<ExamInfo>();
            InspectionList = new List<InspectionInfo>();
        }
    }

    /// <summary>
    /// 就诊队列明细
    /// </summary>
    public class VisitInfo
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 队列科室代码
        /// </summary>
        public string QueueDeptCode { get; set; }

        /// <summary>
        /// 队列科室名称
        /// </summary>
        public string QueueDeptName { get; set; }

        /// <summary>
        /// 队列医生代码
        /// </summary>
        public string QueueDoctorCode { get; set; }

        /// <summary>
        /// 队列医生名称
        /// </summary>
        public string QueueDoctorName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 当前号
        /// </summary>
        public string CurrNo { get; set; }

        /// <summary>
        /// 自己号
        /// </summary>
        public string OwnNo { get; set; }

        /// <summary>
        /// 等待人数
        /// </summary>
        public string WaitCount { get; set; }

        /// <summary>
        /// 队列代码
        /// </summary>
        public string QueueCode { get; set; }
        public string Time { get; set; }
    }

    /// <summary>
    /// 检查队列明细
    /// </summary>
    public class ExamInfo
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }
    }

    /// <summary>
    /// 检验队列明细
    /// </summary>
    public class InspectionInfo
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }
    }
}
