using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Push
{
    public class ExternalReqPushVisitComplete : ExternalReqBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 就诊Id
        /// </summary>
        public string VisitId { get; set; }
        /// <summary>
        /// 证件类型, 患者Id 和证件必须有一个不能为空
        /// </summary>
        public string PaperWorkType { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string PaperWorkNo { get; set; }
        /// <summary>
        /// 单据Id只要可以查询到开的单就可以了
        /// </summary>
        public string Receiptid { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }
    }
}
