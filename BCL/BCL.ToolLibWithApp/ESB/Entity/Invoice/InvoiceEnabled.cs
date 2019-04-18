using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Invoice
{
    public class ExternalReqInvoiceEnabled : ExternalReqBase
    {
        public string OperCode { get; set; }
        public string InvoiceNo { get; set; }
    }
    public class ExternalResInvoiceEnabled : ExternalResBase
    {

    }
}
