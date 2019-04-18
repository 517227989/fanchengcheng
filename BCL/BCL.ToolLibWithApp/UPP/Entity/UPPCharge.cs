using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity
{
    public class UPPReqCharge 
    {
        public string ReqNo { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string AuthCode { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
    }

    public class UPPResCharge : UPPBizResBase
    {
        public string ReqNo { get; set; }
        public string ResNo { get; set; }
        public string Amount { get; set; }
        public string EffectTime { get; set; }
        public string Name { get; set; }
        public string UserNo { get; set; }
        public string PayType { get; set; }
    }
}
