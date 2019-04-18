using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.SMP.Entity
{
    public class SMSReqSend : SMSReqBase
    {
        public string SignName { get; set; }
        public string TempCode { get; set; }
        public string TempArgs { get; set; }
        public string Content { get; set; }
        public string SendDate { get; set; }
    }
    public class SMSResSend : SMSResBase
    {
        public string ResNo { get; set; }
    }
}
