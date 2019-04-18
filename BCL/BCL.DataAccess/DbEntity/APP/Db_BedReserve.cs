using System;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_BedReserve
    {
        /// <summary>
        /// Id
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
        /// 预约Id
        /// </summary>
        public string ReserveId { get; set; }
        /// <summary>
        /// 就诊人Id
        /// </summary>
        public string VisitorId { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 预约提交日期
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 床位类型:0.特需病区（产后病房）
        /// </summary>
        public int BedType { get; set; }
        /// <summary>
        /// 预产期
        /// </summary>
        public DateTime EDC { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 预约状态:1.预约成功,2.预约取消
        /// </summary>
        public int ReserveStatus { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModDate { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModUser { get; set; }
    }
    public class Db_BedReserveMap : EntityTypeConfiguration<Db_BedReserve>
    {
        public Db_BedReserveMap()
        {
            ToTable("APP_BedReserve");
            HasKey(k => k.Id);
        }
    }
}
