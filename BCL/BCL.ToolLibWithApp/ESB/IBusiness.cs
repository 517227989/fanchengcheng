using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB
{
    public partial interface IBusiness
    {
        /// <summary>
        /// 发卡
        /// </summary>
        /// <param name="biz"></param>
        /// <returns></returns>
        string IssueCard(string biz);
        /// <summary>
        /// 打印发票
        /// </summary>
        /// <param name="biz"></param>
        /// <returns></returns>
        string InvoicePrint(string biz);
        /// <summary>
        /// 预交款
        /// </summary>
        /// <param name="biz"></param>
        /// <returns></returns>
        string InHospitalDeposit(string biz);
        /// <summary>
        /// 门诊支付
        /// </summary>
        /// <param name="biz"></param>
        /// <returns></returns>
        string OutPatientChargePay(string biz);
        /// <summary>
        /// 满意度评价
        /// </summary>
        /// <param name="biz"></param>
        /// <returns></returns>
        string ResAddresult(string biz);
    }
}
