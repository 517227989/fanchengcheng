using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class UPPReqOrder 
    {
        public string ReqNo { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string NotifyUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string TradeType { get; set; }
        public string OpenId { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public string TimeExpire { get; set; }
        public string ClientIpAddr { get; set; }
        public string BackParams { get; set; }
        public string IsCanUpdateAmount { get; set; }
        public string PhoneNo { get; set; }
        public string SceneInfo { get; set; }
        public string WXAppId { get; set; }
        public DateTime AddDate { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class UPPResOrder : UPPBizResBase
    {
        public string ReqNo { get; set; }
        public string OrderInfo { get; set; }
    }
}
