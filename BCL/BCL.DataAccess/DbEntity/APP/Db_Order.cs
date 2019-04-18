using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_Order
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 医院代码
        /// </summary>
        public String HospitalId { get; set; }
        /// <summary>
        /// 分院代码
        /// </summary>
        public String BranchCode { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 院内病人Id
        /// </summary>
        public string NosocomialId { get; set; }
        /// <summary>
        /// 订单号（挂号Id、单据Id）
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 费用分类：10->预约费用 11->挂号费用 12->处方费用 13->住院费用 14->账户费用 15->营养膳食
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 结算Id
        /// </summary>
        public string BillId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 请求流水号
        /// </summary>
        public string ReqNo { get; set; }
        /// <summary>
        /// 交易流水号
        /// </summary>
        public string ResNo { get; set; }
        /// <summary>
        /// 交易方式
        /// </summary>
        public string Mode { get; set; }
        /// <summary>
        /// 请求渠道
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 状态1->订单创建2->等待付款3->成功4->关闭5->退款6->退款明细
        /// </summary>
        public Int32 State { get; set; }
        /// <summary>
        /// 订单地址
        /// </summary>
        public string OrderInfo { get; set; }
        /// <summary>
        /// 回传参数
        /// </summary>
        public string BackParams { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? ResDate { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 结算状态 0->未结算 1->结算中 2->结算成功 3->结算失败
        /// </summary>
        public int BillState { get; set; }
    }
    public class Db_OrderMap : EntityTypeConfiguration<Db_Order>
    {
        public Db_OrderMap()
        {
            ToTable("APP_Order");
            HasKey(k => k.Id);
        }
    }
}
