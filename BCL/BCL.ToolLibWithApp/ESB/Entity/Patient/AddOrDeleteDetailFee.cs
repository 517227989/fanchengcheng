namespace BCL.ToolLibWithApp.ESB.Entity.Patient
{
    public class ExternalReqAddOrDeleteDetailFee : ExternalReqBase
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 病案号，退费使用
        /// </summary>
        public string CaseNo { get; set; }
        /// <summary>
        /// 病历本是否收费 1 收费 0 不收费 -1 退费
        /// </summary>
        public string CardFee { get; set; }

        /// <summary>
        /// 费用类型(0:病历本费;1:就诊卡费)
        /// </summary>
        public string FeeType { get; set; }
    }

    public class ExternalResAddOrDeleteDetailFee : ExternalResBase
    {
        /// <summary>
        /// 病案号，收费返回，退费不返回
        /// </summary>
        public string CaseNo { get; set; }
    }
}
