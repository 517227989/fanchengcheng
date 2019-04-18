using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity
{
    public class UPPReqForm 
    {
        public string ReqNo { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string BackParams { get; set; }
        public string NotifyUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public string TimeExpire { get; set; }
    }

    public class UPPResForm : UPPBizResBase
    {
        public string ReqNo { get; set; }
        public string OrderInfo { get; set; }
    }
}
