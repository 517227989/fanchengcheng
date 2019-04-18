using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.InHospital
{
    /*
     * 住院预交款
     */

    public class ExternalReqInHospitalDeposit : ExternalReqBase
    {

        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 住院Id
        /// </summary>
        public string InHospitalId { get; set; }

        /// <summary>
        /// 充值日期
        /// </summary>
        public string DepositDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DepositId { get; set; }

        /// <summary>
        /// 充值详情
        /// </summary>
        public DepositDetail DepositDetail { get; set; }

        //初始化对象
        public ExternalReqInHospitalDeposit()
        {
            DepositDetail = new DepositDetail();
        }
    }

    public class DepositDetail
    {
        /// <summary>
        /// 支付方式代码
        /// </summary>
        public string PayModeCode { get; set; }

        /// <summary>
        /// 支付方式名称
        /// </summary>
        public string PayModeName { get; set; }

        /// <summary>
        /// 支付Id
        /// </summary>
        public string PayId { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        public string PayAmount { get; set; }

        /// <summary>
        /// 支付日期>
        public string PayDate { get; set; }
        /// <summary>
        /// 申请单号
        /// </summary>
        public string ReqNo { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        public string EffectTime { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string UserNo { get; set; }
        /// <summary>
        /// 交易要素
        /// </summary>
        public string TransInfo { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 授权号
        /// </summary>
        public string AuthCode { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string MerchNo { get; set; }
        /// <summary>
        /// 终端号
        /// </summary>
        public string TermNo { get; set; }

        public string AppId { get; set; }
        public string State { get; set; }
        public string Reason { get; set; }
    }

    /*
     * 住院预交款
     */

    public class ExternalResInHospitalDeposit : ExternalResBase
    {
        /// <summary>
        /// 充值Id
        /// </summary>
        public string DepositId { get; set; }

        /// <summary>
        /// 充值后余额
        /// </summary>
        public string DepositBalance { get; set; }

    }
}
