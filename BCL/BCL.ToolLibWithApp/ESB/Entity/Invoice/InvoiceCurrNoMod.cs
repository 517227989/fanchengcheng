using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Invoice
{
    public class ExternalReqInvoiceCurrNoMod : ExternalReqBase
    {
        public string OperCode { get; set; }
        public string CurrNo { get; set; }
    }
    public class ExternalResInvoiceCurrNoMod : ExternalResBase
    {

    }
}
