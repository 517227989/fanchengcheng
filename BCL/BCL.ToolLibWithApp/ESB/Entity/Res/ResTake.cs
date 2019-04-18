using BCL.ToolLibWithApp.ESB.Entity.Reg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Res
{
    /*
    * 预约取号
    */

    public class ExternalReqResTake : ExternalReqBase
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
        /// 是否支付
        /// </summary>
        public string IsPay { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public string PayAmount { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string PaperWorkType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string PaperWorkNo { get; set; }

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 挂号支付明细
        /// </summary>
        [ToolLib.Attribute.IsValidate(false)]
        public List<RegPayInfo> RegPayList { get; set; }

        /** 加入 2019/3/15 将集合改为对象，今后新版本以对象为基础入出参，集合形式以后逐渐移除。修改目的 防止某些不懂业务的传入多条支付明细  **/
        public RegPayInfo RegPayInfo { get; set; }

        public ExternalReqResTake()
        {
            RegPayInfo = new RegPayInfo();
            RegPayList = new List<RegPayInfo>();
        }
    }

    /*
    * 预约取号回应
    */
    public class ExternalResResTake : ExternalResBase
    {
        public RegInfo RegInfo { get; set; }
        public ExternalResResTake()
        {
            RegInfo = new RegInfo();
        }
    }
}

