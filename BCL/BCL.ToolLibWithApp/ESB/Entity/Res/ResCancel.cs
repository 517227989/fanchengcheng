using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Res
{
    /// <summary>
    ///     预约取消
    /// </summary>
    public class ExternalReqResCancel : ExternalReqBase
    {
        /// <summary>
        /// 预约ID
        /// </summary>
        public string ResId { get; set; }

        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }
    }

    /// <summary>
    /// 预约取消
    /// </summary>
    public class ExternalResResCancel : ExternalResBase
    {

    }
}
