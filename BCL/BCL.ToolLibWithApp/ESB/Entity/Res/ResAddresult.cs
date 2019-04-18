using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Res
{
    public class ExternalReqRegAddresult : ExternalReqBase
    {
        public DateTime? SubmitDate { get; set; }
    }

    public class ExternalResResAddresult : ExternalReqBase
    {
        public int Id { get; set; }
        public string Groups { get; set; }
        public string HospitalId { get; set; }
        public string IndexCode { get; set; }
        public string IndexName { get; set; }
        public int? Rating { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string TermCode { get; set; }

    }
}
