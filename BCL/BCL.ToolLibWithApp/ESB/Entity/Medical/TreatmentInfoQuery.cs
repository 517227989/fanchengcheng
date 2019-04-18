using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Medical
{
    public class ExternalReqTreatmentInfoQuery : ExternalReqBase
    {
        public string PatientId { get; set; }
    }

    public class ExternalResTreatmentInfoQuery : ExternalResBase
    {
        public List<VisitInfo> VisitList { get; set; }
        public ExternalResTreatmentInfoQuery()
        {
            VisitList = new List<VisitInfo>();
        }
    }
    public class VisitInfo
    {
        public string VisitId { get; set; }
        public string VisitDate { get; set; }
        public string VisitDeptCode { get; set; }
        public string VisitDeptName { get; set; }
        public string VisitDoctorCode { get; set; }
        public string VisitDoctorName { get; set; }
        public List<DiseaseInfo> DiseaseList { get; set; }
        public VisitInfo()
        {
            DiseaseList = new List<DiseaseInfo>();
        }
    }
    public class DiseaseInfo
    {
        public string VisitId { get; set; }
        public string DiseaseCode { get; set; }
        public string DiseaseName { get; set; }
        public string DiseaseType { get; set; }
        public string DiseaseOrder { get; set; }
    }
}
