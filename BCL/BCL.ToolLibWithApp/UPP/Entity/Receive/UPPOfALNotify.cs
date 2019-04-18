using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Receive
{
    public class UPPOfALNotify
    {
        public string Notify_Time { get; set; }
        public string Notify_Type { get; set; }
        public string Notify_Id { get; set; }
        public string App_Id { get; set; }
        public string Charset { get; set; }
        public string Version { get; set; }
        public string Sign_Type { get; set; }
        public string Sign { get; set; }
		public string Open_Id { get; set; }
		public string Auth_App_Id { get; set; }
        public string Trade_No { get; set; }
        public string Out_Trade_No { get; set; }
        public string Out_Biz_No { get; set; }
        public string Buyer_Id { get; set; }
        public string Buyer_Logon_Id { get; set; }
        public string Seller_Id { get; set; }
        public string Seller_Email { get; set; }
        public string Trade_Status { get; set; }
        public string Total_Amount { get; set; }
        public string Receipt_Amount { get; set; }
        public string Invoice_Amount { get; set; }
        public string Buyer_Pay_Amount { get; set; }
        public string Point_Amount { get; set; }
        public string Refund_Fee { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Gmt_Create { get; set; }
        public string Gmt_Payment { get; set; }
        public string Gmt_Refund { get; set; }
        public string Gmt_Close { get; set; }
        public string Fund_Bill_List { get; set; }
        public string Passback_Params { get; set; }
        public string Voucher_Detail_List { get; set; }
    }
}
