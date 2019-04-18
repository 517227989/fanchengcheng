using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Receive
{
    public class UPPOfDPNotify
    {
        public string POSID { get; set; }
        public string BRANCHID { get; set; }
        public string ORDERID { get; set; }
        public string PAYMENT { get; set; }
        public string CURCODE { get; set; }
        public string REMARK1 { get; set; }
        public string REMARK2 { get; set; }
        public string ACC_TYPE { get; set; }
        public string SUCCESS { get; set; }
        public string TYPE { get; set; }
        public string REFERER { get; set; }
        public string CLIENTIP { get; set; }
        public string ACCDATE { get; set; }
        public string USRMSG { get; set; }
        public string USRINFO { get; set; }
        public string PAYTYPE { get; set; }
        public string SIGN { get; set; }
    }
}
