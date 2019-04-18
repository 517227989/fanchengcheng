using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Reg
{
    /*
    * 挂号取消 add by rj
    */
    public class ExternalReqRegCancel : ExternalReqBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 挂号Id
        /// </summary>
        public string RegId { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// 取消类型
        /// </summary>
        public string CancelType { get; set; }
        public string DayId { get; set; }
        public string Time { get; set; }
        public string Number { get; set; }
    }

    public class ExternalResRegCancel : ExternalResBase
    {
    }
}
