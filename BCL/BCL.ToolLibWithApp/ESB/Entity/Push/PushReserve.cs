using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Push
{
    public class ExternalReqPushReserve : ExternalReqBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 证件类型, 患者Id 和证件必须有一个不能为空
        /// </summary>
        public string PaperWorkType { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string PaperWorkNo { get; set; }
        /// <summary>
        /// 预约号
        /// </summary>
        public string ResId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }
    }
}
