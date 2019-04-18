using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Reg
{
    /*
    * 挂号支付
    */
    public class ExternalReqRegPay : ExternalReqBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCardNo { get; set; }
        /// <summary>
        /// 挂号Id
        /// </summary>
        public string RegId { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public string PayAmount { get; set; }

        public string DayId { get; set; }

        public string ReceiveParams { get; set; }

        public string Number { get; set; }
        /// <summary>
        /// 挂号支付明细
        /// </summary>
        [ToolLib.Attribute.IsValidate(false)]
        public List<RegPayInfo> RegPayList { get; set; }
        /** 加入 2019/3/15 将集合改为对象，今后新版本以对象为基础入出参，集合形式以后逐渐移除。修改目的 防止某些不懂业务的传入多条支付明细  **/
        public RegPayInfo RegPayInfo { get; set; }
        public ExternalReqRegPay()
        {
            RegPayList = new List<RegPayInfo>();
        }

    }

    public class RegPayInfo
    {
        /// <summary>
        /// 挂号Id
        /// </summary>
        public string RegId { get; set; }
        /// <summary>
        /// 支付渠道
        /// </summary>
        public string PayChannel { get; set; }
        /// <summary>
        /// 支付Id
        /// </summary>
        public string PayId { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public string PayAmount { get; set; }
        /// <summary>
        /// 支付日期
        /// </summary>
        public string PayDateTime { get; set; }

    }

    /*
    * 挂号支付
    */
    public class ExternalResRegPay : ExternalResBase
    {
        public string BillId { get; set; }
        public string RegId { get; set; }
        public string Number { get; set; }
    }
}
