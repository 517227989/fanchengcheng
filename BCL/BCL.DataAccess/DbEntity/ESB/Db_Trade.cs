using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Trade
    {
        /// <summary>
        /// Id主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 区域代码
        /// </summary>
        public string DistrictCode { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// 医院Id
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 医院代码
        /// </summary>
        public string HospitalCode { get; set; }
        /// <summary>
        /// 业务类名
        /// </summary>
        public string BusinessName { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; set; }
        /// <summary>
        /// 是否异步
        /// </summary>
        public string Async { get; set; }
        /// <summary>
        /// 对外名称
        /// </summary>
        public string ExternalName { get; set; }
        /// <summary>
        /// 对内名称
        /// </summary>
        public string InternalName { get; set; }
        /// <summary>
        /// 交易描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 激活标志
        /// </summary>
        public int Active { get; set; }
        /// <summary>
        /// 是否记录日志表
        /// </summary>
        public int IsTabRecord { get; set; }
    }
    public class Db_TradeMapper : EntityTypeConfiguration<Db_Trade>
    {
        public Db_TradeMapper()
        {
            ToTable("AT_Trade");
            HasKey(o => o.Id);
        }
    }
}
