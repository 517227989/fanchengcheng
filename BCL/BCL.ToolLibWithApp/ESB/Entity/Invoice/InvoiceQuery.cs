using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Invoice
{
    public class ExternalReqInvoiceQuery : ExternalReqBase
    {
        public string OperCode { get; set; }
    }
    public class ExternalResInvoiceQuery : ExternalResBase
    {
        public List<TakeInvoiceInfo> InvoiceList { get; set; }
        public ExternalResInvoiceQuery()
        {
            InvoiceList = new List<TakeInvoiceInfo>();
        }
    }
    public class TakeInvoiceInfo
    {
        public string BegNum { get; set; }
        public string EndNum { get; set; }
        public string TakeDate { get; set; }
        public string InvoiceNo { get; set; }
    }
}
