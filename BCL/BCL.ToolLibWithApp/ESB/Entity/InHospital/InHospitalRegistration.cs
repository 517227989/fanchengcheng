namespace BCL.ToolLibWithApp.ESB.Entity.InHospital
{
    /// <summary>
    /// 住院申请和登记
    /// </summary>
    public class ExternalReqInHospitalRegistration : ExternalReqBase
    {
        public ExternalReqInHospitalRegistration()
        {
            DepositDetail = new DepositDetail();
        }

        public string ApplyId { get; set; }
        public string PatientType { get; set; }
        public string DepositPayAmount { get; set; }

        public DepositDetail DepositDetail { get; set; }
    }

    public class ExternalResInHospitalRegistration : ExternalResBase
    {
        public ExternalResInHospitalRegistration()
        {
            InHosRegInfo = new InHosRegInfo();
        }
        public InHosRegInfo InHosRegInfo { get; set; }
    }
}
