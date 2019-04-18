using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.SSP
{
    /// <summary>
    /// 自助机硬件状态检测
    /// </summary>
    public class Db_TermMonitor
    { 
        /// <summary>
        /// 设备id
        /// </summary>
        public string TermId { get; set; }
        /// <summary>
        /// 监测类型
        /// </summary>
        public string MonitorType { get; set; }
        /// <summary>
        /// 状态:0.正常,非0.异常
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 状态说明
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public string ModDate { get; set; }
    }
}
