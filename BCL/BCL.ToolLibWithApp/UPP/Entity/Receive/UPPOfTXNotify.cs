using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BCL.ToolLibWithApp.UPP.Entity.Receive
{
	[XmlRoot("xml")]
    public class UPPOfTXRes
    {
        public string return_code { get; set; }
        public string return_msg { get; set; }
    }
    [XmlRoot("xml")]
    public class UPPOfTXOfRes
    {
        [XmlIgnore]
        public string return_code { get; set; }
        [XmlIgnore]
        public string return_msg { get; set; }

        [XmlElement("return_code")]
        public XmlNode return_code1
        {
            get
            {
                XmlNode node = new XmlDocument().CreateNode(XmlNodeType.CDATA, "", "");
                node.InnerText = return_code;
                return node;
            }
            set { return_code = value.Value; }
        }
        [XmlElement("return_msg")]
        public XmlNode return_msg1
        {
            get
            {
                XmlNode node = new XmlDocument().CreateNode(XmlNodeType.CDATA, "", "");
                node.InnerText = return_msg;
                return node;
            }
            set { return_msg = value.Value; }
        }
    }
    [XmlRoot("xml")]
    public class UPPOfTXNotify : UPPOfTXRes
    {
        public string appid { get; set; }
        public string mch_id { get; set; }
        public string sub_appid { get; set; }
        public string sub_mch_id { get; set; }
        public string device_info { get; set; }
        public string nonce_str { get; set; }
        public string sub_is_subscribe { get; set; }
        public string sign { get; set; }
        public string sign_type { get; set; }
        public string result_code { get; set; }
        public string err_code { get; set; }
        public string err_code_des { get; set; }
        public string openid { get; set; }
        public string sub_openid { get; set; }
        public string is_subscribe { get; set; }
        public string trade_type { get; set; }
        public string bank_type { get; set; }
        public string total_fee { get; set; }
        public string settlement_total_fee { get; set; }
        public string fee_type { get; set; }
        public string cash_fee { get; set; }
        public string cash_fee_type { get; set; }
        public string transaction_id { get; set; }
        public string out_trade_no { get; set; }
        public string attach { get; set; }
        public string time_end { get; set; }
        public string coupon_fee { get; set; }
        public string coupon_count { get; set; }
        public string coupon_id_0 { get; set; }
        public string coupon_id_1 { get; set; }
        public string coupon_id_2 { get; set; }
        public string coupon_fee_0 { get; set; }
        public string coupon_fee_1 { get; set; }
        public string coupon_fee_2 { get; set; }
    }
}
