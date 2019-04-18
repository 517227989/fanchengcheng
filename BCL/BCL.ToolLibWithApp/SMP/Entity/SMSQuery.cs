using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.SMP.Entity
{
    public class SMSReqQuery : SMSReqBase
    {
        public string ResNo { get; set; }
        public string SendDate { get; set; }
    }
    public class SMSResQuery : SMSResBase
    {
        public List<Details> Details { get; set; }
    }
    public class Details
    {
        public string PhoneNo { get; set; }
        public string ErrCode { get; set; }
        public string TempCode { get; set; }
        public string Content { get; set; }
        public string SendDate { get; set; }
        public string RecvDate { get; set; }
        public string ReqNo { get; set; }
        public string State { get; set; }
    }
}
