using BCL.ToolLibWithApp.ESB.Entity.Reg;
using System.Collections.Generic;

namespace BCL.ToolLibWithApp.ESB.Entity.Res
{
    /*
    * 挂号取消
    */
    public class ExternalReqResPay : ExternalReqBase
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
        /// 支付金额
        /// </summary>
        public string PayAmount { get; set; }

        /// <summary>
        /// 挂号支付明细
        /// </summary>
        [ToolLib.Attribute.IsValidate(false)]
        public List<RegPayInfo> RegPayList { get; set; }

        /** 加入 2019/3/15 将集合改为对象，今后新版本以对象为基础入出参，集合形式以后逐渐移除。修改目的 防止某些不懂业务的传入多条支付明细  **/
        public RegPayInfo RegPayInfo { get; set; }

        public ExternalReqResPay()
        {
            RegPayList = new List<RegPayInfo>();
        }
    }
    public class ExternalResResPay : ExternalResBase
    {
        public string BillId { get; set; }
        public string Number { get; set; }
    }
}
