using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.InHospital
{
    public class ExternalReqInHospitalDepositQuery : ExternalReqBase
    {
        public string PatientId { get; set; }
        public string InHospitalId { get; set; }

    }

    public class ExternalResInHospitalDepositQuery : ExternalResBase
    {
        /// <summary>
        /// 预交款总额
        /// </summary>
        public string DepositAmount { get; set; }
        /// <summary>
        /// 预交款余额
        /// </summary>
        public string DepositBalance { get; set; }
        /// <summary>
        /// 充值明细
        /// </summary>
        public List<DepositInfo> DepositList { get; set; }
        public ExternalResInHospitalDepositQuery()
        {
            DepositList = new List<DepositInfo>();
        }
    }

    public class DepositInfo
    {
        /// <summary>
        /// 住院Id
        /// </summary>
        public string InHospitalId { get; set; }
        /// <summary>
        /// 充值Id
        /// </summary>
        public string DepositId { get; set; }
        /// <summary>
        /// 充值后余额
        /// </summary>
        public string DepositBalance { get; set; }
        /// <summary>
        /// 充值日期
        /// </summary>
        public string DepositDate { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public string DepositAmount { get; set; }
        /// <summary>
        /// 可退金额
        /// </summary>
        public string RefundableAmount { get; set; }
        /// <summary>
        /// 充值详情
        /// </summary>
        public DepositDetail DepositDetail { get; set; }
        public DepositInfo()
        {
            DepositDetail = new DepositDetail();
        }
    }
}
