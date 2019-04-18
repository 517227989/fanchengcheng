using System;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess.DbEntity.APP
{
    /// <summary>
    /// 业务使用量统计
    /// </summary>
    public class Db_Statistics
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 统计记录Id
        /// </summary>
        public string StatisticId { get; set; }
        /// <summary>
        /// 医院Id
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public string Business { get; set; }
        /// <summary>
        /// 操作类型（1：查询；2：操作）
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 就诊人Id
        /// </summary>
        public string VisitorId { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public int IsCompleted { get; set; }
        /// <summary>
        /// 个推用户Id
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// 设备Id
        /// </summary>
        public string DeviceId { get; set; }
        /// <summary>
        /// 手机型号
        /// </summary>
        public string PhoneModel { get; set; }
        /// <summary>
        /// 手机品牌
        /// </summary>
        public string PhoneBrand { get; set; }
        /// <summary>
        /// 操作系统
        /// </summary>
        public string OSVersion { get; set; }
        /// <summary>
        /// 网络地址
        /// </summary>
        public string MacAddress { get; set; }
        /// <summary>
        /// IMEI
        /// </summary>
        public string Imei { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal Amount { get; set; }
    }
    public class Db_StatisticsMap : EntityTypeConfiguration<Db_Statistics>
    {
        public Db_StatisticsMap()
        {
            ToTable("APP_Statistics");
            HasKey(k => k.Id);
        }
    }
}
