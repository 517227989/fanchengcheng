using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess
{
    public class Db_BillDetail_Hospital
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 医院Id
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 对账渠道
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string RollChannel { get; set; }
        /// <summary>
        /// 交易渠道:参照代码表
        /// </summary>
        public string TradeChannel { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal TradeAmount { get; set; }
        /// <summary>
        /// 导入时间
        /// </summary>
        public DateTime ImportTime { get; set; }
        /// <summary>
        /// 交易请求日期
        /// </summary>
        public DateTime? ReqDate { get; set; }
        /// <summary>
        /// 交易返回日期
        /// </summary>
        public DateTime? ResDate { get; set; }
        /// <summary>
        /// 日报日期
        /// </summary>
        public DateTime? ReportDate { get; set; }
        /// <summary>
        /// 日报id
        /// </summary>
        public string ReportId { get; set; }

        /// <summary>
        /// 交易场景:参照代码表
        /// </summary>
        public string TradeScene { get; set; }
        /// <summary>
        /// 交易类型:1.收费,-1退费
        /// </summary>
        public int TradeType { get; set; }

        /// <summary>
        /// 交易应用:参照代码表
        /// </summary>
        public string TradeApp { get; set; }
        /// <summary>
        /// 厂商代码
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// 厂商名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }
        /// <summary>
        /// 分院名称
        /// </summary>
        public string BranchName { get; set; }
        /// <summary>
        /// 终端代码
        /// </summary>
        public string TermCode { get; set; }

        /// <summary>
        /// 终端名称
        /// </summary>
        public string TermName { get; set; }
        /// <summary>
        /// 操作工号
        /// </summary>
        public string OperCode { get; set; }
        /// <summary>
        /// 渠道交易流水号
        /// </summary>
        public string ChannelId { get; set; }
        /// <summary>
        /// 医院交易流水号
        /// </summary>
        public string HisTradeId { get; set; }
        /// <summary>
        /// 医院业务流水号
        /// </summary>
        public string HisBizId { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCardNo { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string MerchantId { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string AccountBank { get; set; }
        /// <summary>
        /// 收单银行
        /// </summary>
        public string PayBank { get; set; }
        /// <summary>
        /// 退款日期
        /// </summary>
        public DateTime? RefundDate { get; set; }
        /// <summary>
        /// 原渠道交易流水号
        /// </summary>
        public string OldChannelId { get; set; }
        /// <summary>
        /// 原医院交易流水号
        /// </summary>
        public string OldHisTradeId { get; set; }
        /// <summary>
        /// 原批次号
        /// </summary>
        public string OldBatchNo { get; set; }
        /// <summary>
        /// 原商户号
        /// </summary>
        public string OldMerchantId { get; set; }
        /// <summary>
        /// 医院患者Id
        /// </summary>
        public string HisPatientId { get; set; }
        /// <summary>
        /// 用户证件类型:参照代码表
        /// </summary>
        public string PaperWorkType { get; set; }
        /// <summary>
        /// 用户证件号码
        /// </summary>
        public string PaperWorkNo { get; set; }
        /// <summary>
        /// 就诊卡号
        /// </summary>
        public string VisitCardNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 异常标志:0.正常,1.单边账,-1.金额不一致
        /// </summary>
        public int IsException { get; set; }
        /// <summary>
        /// 差额(如不一致)
        /// </summary>
        public decimal Disparity { get; set; }
        /// <summary>
        /// 其他明细1
        /// </summary>
        public string OtherDetail1 { get; set; }
        /// <summary>
        /// 其他明细2
        /// </summary>
        public string OtherDetail2 { get; set; }
        /// <summary>
        /// 其他明细3
        /// </summary>
        public string OtherDetail3 { get; set; }
        /// <summary>
        /// 其他明细4
        /// </summary>
        public string OtherDetail4 { get; set; }
        /// <summary>
        /// 其他明细5
        /// </summary>
        public string OtherDetail5 { get; set; }
        /// <summary>
        /// 其他明细6
        /// </summary>
        public string OtherDetail6 { get; set; }
        /// <summary>
        /// 其他明细7
        /// </summary>
        public string OtherDetail7 { get; set; }
        /// <summary>
        /// 其他明细8
        /// </summary>
        public string OtherDetail8 { get; set; }
        /// <summary>
        /// 其他明细9
        /// </summary>
        public string OtherDetail9 { get; set; }
        /// <summary>
        /// 其他明细10
        /// </summary>
        public string OtherDetail10 { get; set; }
    }
    public class Db_BillDetail_HospitalMapper : EntityTypeConfiguration<Db_BillDetail_Hospital>
    {
        public Db_BillDetail_HospitalMapper()
        {
            ToTable("UT_BillDetail_Hospital");
            HasKey(o => o.Id);
        }
    }
}
