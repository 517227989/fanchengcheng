using System.Collections.Generic;

namespace BCL.ToolLibWithApp.ESB.Entity.Reg
{
    /*
    * 排班
    */

    public class ExternalReqSchedulings : ExternalReqBase
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        public string BeginDateTime { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDateTime { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 医生代码
        /// </summary>
        public string DoctorCode { get; set; }
    }

    /*
    * 排班
    */
    public class ExternalResSchedulings : ExternalResBase
    {
        public List<SchedulingInfo> SchedulingList { get; set; }

        public ExternalResSchedulings()
        {
            SchedulingList = new List<SchedulingInfo>();
        }
    }

    /*
    * 排班明细
    */

    public class SchedulingInfo
    {
        /// <summary>
        /// 日排班Id
        /// </summary>
        public string DayId { get; set; }

        /// <summary>
        /// 周排班Id
        /// </summary>
        public string WeekId { get; set; }

        /// <summary>
        /// 排班日期
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 排班科室代码
        /// </summary>
        public string DeptCode { get; set; }

        /// <summary>
        /// 排班科室名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 排班医生代码
        /// </summary>
        public string DoctorCode { get; set; }

        /// <summary>
        /// 排班医生名称
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 排班类别代码
        /// </summary>
        public string TypeCode { get; set; }

        /// <summary>
        /// 排班类别名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 排班班次
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 挂号金额
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// 号源总数
        /// </summary>
        public string TotalCount { get; set; }

        /// <summary>
        /// 号源剩余数
        /// </summary>
        public string SurplusCount { get; set; }

        /// <summary>
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        /// 分院名称
        /// </summary>
        public string BranchName { get; set; }

    }
}
