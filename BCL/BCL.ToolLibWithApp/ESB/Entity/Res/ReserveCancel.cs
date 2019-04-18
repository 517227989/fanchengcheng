using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Res
{
    /*
    * 挂号取消
    */
    public class ExternalReqReserveCancel : ExternalReqBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 预约Id
        /// </summary>
        public string ResId { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string PaperWorkType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string PaperWorkNo { get; set; }
    }

    public class ExternalResReserveCancel : ExternalResBase
    {
    }
}
