using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Reg
{
    /// <summary>
    /// 
    /// </summary>
    public class ExternalReqNumberSources : ExternalReqBase
    {
        /// <summary>
        /// 日排班Id
        /// </summary>
        public string DayId { get; set; }
        public string Time { get; set; }

    }

    /*
    * 号源出参
    */
    public class ExternalResNumberSources : ExternalResBase
    {
        public List<NumberSourceInfo> NumberSourceList { get; set; }
        public ExternalResNumberSources()
        {
            NumberSourceList = new List<NumberSourceInfo>();
        }
    }

    /*
    * 号源明细
    */

    public class NumberSourceInfo
    {
        /// <summary>
        /// 日排班Id
        /// </summary>
        public string DayId { get; set; }

        /// <summary>
        /// 号源号码
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 号源就诊时间
        /// </summary>
        public string NumberVisitTime { get; set; }
        /// <summary>
        /// 本时段总数
        /// </summary>
        public string TimeTotalCount { get; set; }
        /// <summary>
        /// 本时段剩余数
        /// </summary>
        public string TimeSurplusCount { get; set; }
    }
}
