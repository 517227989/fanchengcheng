using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Invoice
{
    public class ExternalReqInvoiceCurrNoQuery : ExternalReqBase
    {
        public string OperCode { get; set; }
    }
    public class ExternalResInvoiceCurrNoQuery : ExternalResBase
    {
        public string CurrNo { get; set; }
        public string BegNum { get; set; }
        public string EndNum { get; set; }
        public string InvoiceNo { get; set; }
    }
}
