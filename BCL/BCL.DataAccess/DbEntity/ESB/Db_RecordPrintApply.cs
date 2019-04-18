using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_RecordPrintApply
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 申请号
        /// </summary>
        public string ApplyNo { get; set; }
        /// <summary>
        /// 患者住院Id
        /// </summary>
        public string PInHospitalId { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 1.待修改 2.待审核 3.待支付 4.待发货  5.待收货 6.已签收  99.已取消
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime ApplyDate { get; set; }
        /// <summary>
        /// 申请原因,多个用|分隔,公用代码03001
        /// </summary>
        public string ApplyReason { get; set; }
        /// <summary>
        /// 其他申请理由
        /// </summary>
        public string ApplyReasonOther { get; set; }
        /// <summary>
        /// 特殊要求
        /// </summary>
        public string SpecialRequire { get; set; }
        /// <summary>
        /// 报销所在地
        /// </summary>
        public string ReimbursementPlace { get; set; }
        /// <summary>
        /// 复印内容,公用代码,多个用|分隔,公用代码03002
        /// </summary>
        public string CopyContent { get; set; }
        /// <summary>
        /// 其他复印内容
        /// </summary>
        public string CopyContentOther { get; set; }
        /// <summary>
        /// 复印数量
        /// </summary>
        public int CopyNumber { get; set; }
        /// <summary>
        /// 证件类型,公用代码03003
        /// </summary>
        public string PaperWorkType { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string PaperWorkNo { get; set; }
        /// <summary>
        /// 证件照正面
        /// </summary>
        public string IDPhotoFront { get; set; }
        /// <summary>
        /// 证件照反面
        /// </summary>
        public string IDPhotoFeverse { get; set; }
        /// <summary>
        /// 手持照片
        /// </summary>
        public string HoldPhoto { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? AuditDate { get; set; }
        /// <summary>
        /// 审核费用
        /// </summary>
        public decimal AuditFee { get; set; }
        /// <summary>
        /// 审核费用说明
        /// </summary>
        public string FeeExplain { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int? PayMode { get; set; }
        /// <summary>
        /// 支付商家
        /// </summary>
        public string PayMerchant { get; set; }
        /// <summary>
        /// 支付状态：1,待支付 2.支付完成
        /// </summary>
        public int? PayState { get; set; }
        /// <summary>
        /// 支付交易码（申请码）
        /// </summary>
        public string PayNo { get; set; }
        /// <summary>
        /// 支付渠道流水号
        /// </summary>
        public string PayChannelNo { get; set; }
        /// <summary>
        /// 实际支付费用
        /// </summary>
        public decimal? PayFee { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? PayDate { get; set; }
        /// <summary>
        /// 领取方式 1.自取 2.快递
        /// </summary>
        public int CollectionMode { get; set; }
        /// <summary>
        /// 快递公司
        /// </summary>
        public string ExpressCompany { get; set; }
        /// <summary>
        /// 快递号
        /// </summary>
        public string ExpressNo { get; set; }
        /// <summary>
        /// 收件地址
        /// </summary>
        public string ShippingAddress { get; set; }
        /// <summary>
        /// 发货日期
        /// </summary>
        public DateTime? ShippingDate { get; set; }
        /// <summary>
        /// 收件人电话
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        public string Addressee { get; set; }
        /// <summary>
        /// 签收日期
        /// </summary>
        public DateTime? ReceiptDate { get; set; }
        /// <summary>
        /// 签收人
        /// </summary>
        public string Consignee { get; set; }
        /// <summary>
        /// 申请失败原因
        /// </summary>
        public string FailReason { get; set; }
        /// <summary>
        /// 是否委托1否2是
        /// </summary>
        public int IsEntrust { get; set; }
        /// <summary>
        /// 委托人关系
        /// </summary>
        public string EntrustRelations { get; set; }
        /// <summary>
        /// 取消日期
        /// </summary>
        public DateTime? CancelDate { get; set; }
    }
    public class Db_RecordPrintApplyMapper : EntityTypeConfiguration<Db_RecordPrintApply>
    {
        public Db_RecordPrintApplyMapper()
        {
            ToTable("Mr_RecordPrintApply");
            HasKey(k => new { k.Id });
        }
    }
}
