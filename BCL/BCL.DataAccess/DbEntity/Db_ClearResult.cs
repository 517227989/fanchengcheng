using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess
{
    public class Db_ClearResult
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 医院Id
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }
        /// <summary>
        /// 清分日期
        /// </summary>
        public DateTime ClearDate { get; set; }
        /// <summary>
        /// 清分号
        /// </summary>
        public string ClearNo { get; set; }
        /// <summary>
        /// 清分开始日期
        /// </summary>
        public DateTime BeginDate { get; set; }
        /// <summary>
        /// 清分结束日期
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 商户编号
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 商户名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 商户所属机构编号
        /// </summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 商户所属机构名称
        /// </summary>
        public string AppName { get; set; }
        /// <summary>
        /// 商户净入账总金额(元)
        /// </summary>
        public decimal NetIncome { get; set; }
        /// <summary>
        /// 正交易总笔数
        /// </summary>
        public int PositiveCount { get; set; }
        /// <summary>
        /// 正交易总金额(元)
        /// </summary>
        public decimal PositiveAmount { get; set; }
        /// <summary>
        /// 反交易总笔数
        /// </summary>
        public int NegativeCount { get; set; }
        /// <summary>
        /// 反交易总金额(元)
        /// </summary>
        public decimal NegativeAmount { get; set; }
        /// <summary>
        /// 商户净总交易金额(元)
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 商户净总手续费(元)
        /// </summary>
        public decimal Poundage { get; set; }
        /// <summary>
        /// 隔日退款总金额
        /// </summary>
        public decimal NextDayRefundAmount { get; set; }
        /// <summary>
        /// 调账总金额
        /// </summary>
        public decimal AdjustmentAmount { get; set; }
        /// <summary>
        /// 商户入账状态 0已清分
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 商户入账失败原因
        /// </summary>
        public string FailReasons { get; set; }
        /// <summary>
        /// 商户结算账号
        /// </summary>
        public string AccountNo { get; set; }
        /// <summary>
        /// 商户结算账号名称
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// 短信发送标志:0.未发送,1.已发送,2.发送失败
        /// </summary>
        public int IsSendMessage { get; set; }
        /// <summary>
        /// 短信发送时间
        /// </summary>
        public DateTime MessageTime { get; set; }
        /// <summary>
        /// 邮件发送标志:0.未发送,1.已发送,2.发送失败
        /// </summary>
        public int IsSendEmail { get; set; }
        /// <summary>
        /// 邮件发送时间
        /// </summary>
        public DateTime EmailTime { get; set; }
        /// <summary>
        /// 清分说明
        /// </summary>
        public string Comment { get; set; }
    }
    public class Db_ClearResultMapper : EntityTypeConfiguration<Db_ClearResult>
    {
        public Db_ClearResultMapper()
        {
            ToTable("UT_ClearResult");
            HasKey(o => o.Id);
        }
    }
}
