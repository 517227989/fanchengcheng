using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess
{
    public class Db_ReconcileResult
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
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }
        /// <summary>
        /// 分院名称
        /// </summary>
        public string BranchName { get; set; }
        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 对账渠道:取值参见代码表
        /// </summary>
        public string ReconcileChannel { get; set; }
        /// <summary>
        /// 对账开始日期
        /// </summary>
        public DateTime ReconcileBgnDate { get; set; }
        /// <summary>
        /// 对账结束日期
        /// </summary>
        public DateTime ReconcileEndDate { get; set; }
        /// <summary>
        /// 对账结果:0.账平,1.渠道多,2.医院多,-1.未出账单
        /// </summary>
        public int ReconcileResult { get; set; }
        /// <summary>
        /// 对账时间
        /// </summary>
        public DateTime ReconcileTime { get; set; }
        /// <summary>
        /// 对账人
        /// </summary>
        public string ReconcileUser { get; set; }
        /// <summary>
        /// 渠道总笔数
        /// </summary>
        public int CCount { get; set; }
        /// <summary>
        /// 渠道总金额
        /// </summary>
        public decimal CAmount { get; set; }
        /// <summary>
        /// 渠道总退款笔数
        /// </summary>
        public int CRefoundCount { get; set; }
        /// <summary>
        /// 渠道总退款金额
        /// </summary>
        public decimal CRefoundAmount { get; set; }
        /// <summary>
        /// 渠道净收入金额
        /// </summary>
        public decimal CNetIncome { get; set; }
        /// <summary>
        /// 医院总笔数
        /// </summary>
        public int HCount { get; set; }
        /// <summary>
        /// 医院总金额
        /// </summary>
        public decimal HAmount { get; set; }
        /// <summary>
        /// 医院总退款笔数
        /// </summary>
        public int HRefoundCount { get; set; }
        /// <summary>
        /// 医院总退款金额
        /// </summary>
        public decimal HRefoundAmount { get; set; }

        /// <summary>
        /// 医院净收入金额
        /// </summary>
        public decimal HNetIncome { get; set; }

        /// <summary>
        /// 渠道隔日退款金额
        /// </summary>
        public decimal CNextDayRefundAmount { get; set; }

        /// <summary>
        /// 渠道调账金额
        /// </summary>
        public decimal CAdjustmentAmount { get; set; }
        /// <summary>
        /// 短信发送标志:0.未发送,1.已发送,2.发送失败
        /// </summary>
        public int IsSendMessage { get; set; }
        /// <summary>
        /// 短信发送时间
        /// </summary>
        public DateTime MessageTime { get; set; }
        /// <summary>
        /// 邮件发送时间
        /// </summary>
        public DateTime EmailTime { get; set; }
        /// <summary>
        /// 邮件发送标志:0.未发送,1.已发送,2.发送失败
        /// </summary>
        public int IsSendEmail { get; set; }
        /// <summary>
        /// 对账说明
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 对账清分标志:0.未清分,1.已清分
        /// </summary>
        public int IsClear { get; set; }
    }
    public class Db_ReconcileResultMapper : EntityTypeConfiguration<Db_ReconcileResult>
    {
        public Db_ReconcileResultMapper()
        {
            ToTable("UT_ReconcileResult");
            HasKey(o => o.Id);
        }
    }
}
