using System.Collections.Generic;

namespace BCL.ToolLibWithApp.ESB.Entity.InHospital
{
    public class ExternalReqInHospitalApplyQuery : ExternalReqBase
    {
        public string PatientId { get; set; }
        public string CardType { get; set; }
        public string CardNo { get; set; }
        public string CardInfo { get; set; }
        public string AcquisitionMode { get; set; }
        public string AcquisitionValue { get; set; }
        public string ReceiveParams { get; set; }
        public string EMPI { get; set; }
    }

    public class ExternalResInHospitalApplyQuery : ExternalResBase
    {
        public ExternalResInHospitalApplyQuery()
        {
            InHosApplyList = new List<InHosApplyInfo>();
        }

        public List<InHosApplyInfo> InHosApplyList;
    }

    public class InHosApplyInfo
    {
        public string ApplyId { get; set; }
        public string ApplyDate { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string PatientType { get; set; }
        public string TypeName { get; set; }
        public string NatureCode { get; set; }
        public string NatureName { get; set; }
        public string Birthday { get; set; }
        public string PaperWorkType { get; set; }
        public string PaperWorkNo { get; set; }
        public string MobilePhoneNo { get; set; }
        public string HomeAddress { get; set; }
        public string HomePhoneNo { get; set; }
        public string WorkAddress { get; set; }
        public string WorkPhoneNo { get; set; }
        public string DiseaseCode { get; set; }
        public string DiseaseName { get; set; }
        public string ApplyDeptCode { get; set; }
        public string ApplyDeptName { get; set; }
        public string ApplyDoctorCode { get; set; }
        public string ApplyDoctorName { get; set; }
        public string LimitBalance { get; set; }
        public string WardCode { get; set; }
        public string WardName { get; set; }
        public string PatientId { get; set; }
    }
}
