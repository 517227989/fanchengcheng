using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Receive
{
    public class UPPOfALAgreeNotify
    {
        public string app_id { get; set; }
        public string auth_app_id { get; set; }
        public string external_agreement_no { get; set; }
        public string personal_product_code { get; set; }
        public string valid_time { get; set; }
        public string agreement_no { get; set; }
        public string zm_open_id { get; set; }
        public string invalid_time { get; set; }
        public string sign_scene { get; set; }
        public string sign_time { get; set; }
        public string alipay_user_id { get; set; }
        public string status { get; set; }
        public string forex_eligible { get; set; }
        public string external_logon_id { get; set; }
        public string alipay_logon_id { get; set; }
        public string notify_type { get; set; }
        public string zm_score { get; set; }
        public string login_token { get; set; }
        public string device_id { get; set; }
        public string unsign_time { get; set; }
    }
}
