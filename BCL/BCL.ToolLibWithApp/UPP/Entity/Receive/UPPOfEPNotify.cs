using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Receive
{
    public class UPPOfEPNotify
    {
        public string from { get; set; }
        public string api { get; set; }
        public string app_id { get; set; }
        public string charset { get; set; }
        public string format { get; set; }
        public string encrypt_type { get; set; }
        public string timestamp { get; set; }
        public string sign_type { get; set; }
        public string sign { get; set; }
        public string biz_content { get; set; }
    }
    public class UPPOfEPNotifyOfBizContent
    {
        public string return_code { get; set; }
        public string return_msg { get; set; }
        public string msg_id { get; set; }
        public string cust_id { get; set; }
        public string card_no { get; set; }
        public string total_amt { get; set; }
        public string point_amt { get; set; }
        public string ecoupon_amt { get; set; }
        public string mer_disc_amt { get; set; }
        public string coupon_amt { get; set; }
        public string bank_disc_amt { get; set; }
        public string payment_amt { get; set; }
        public string out_trade_no { get; set; }
        public string order_id { get; set; }
        public string pay_time { get; set; }
        public string total_disc_amt { get; set; }
        public string mer_id { get; set; }
        public string attach { get; set; }
    }
}
