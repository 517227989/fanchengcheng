using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity
{
    public class UPPReqMchAccQuery
    {
        public string Date { get; set; }
    }
    public class UPPResMchAccQuery
    {
        public string PayAmount { get; set; }
        public string RefundAmount { get; set; }
        public string Balance { get; set; }
    }
}
