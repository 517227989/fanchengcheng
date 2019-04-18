using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.SMP.Entity
{
    public class SMSResReport
    {
        public string PhoneNo { get; set; }
        public string ReqNo { get; set; }
        public string ResNo { get; set; }
        public string SendDate { get; set; }
        public string ReportDate { get; set; }
        public string ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public string State { get; set; }
    }
}
