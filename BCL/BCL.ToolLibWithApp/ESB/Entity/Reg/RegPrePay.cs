using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Reg
{
    /*
    * 挂号预支付
    */

    public class ExternalReqRegPrePay : ExternalReqBase
    {
        public string RegId { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCardNo { get; set; }
    }

    public class ExternalResRegPrePay : ExternalResBase
    {
    }
}
