using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.XAI
{
    /// <summary>
    /// 用户索引表
    /// </summary>
    public class Db_UserIndex
    {
        public int Id { get; set; }
        /// <summary>
        /// 医院Id
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户索引
        /// </summary>
        public string Index { get; set; }
        /// <summary>
        /// 索引类型（1、就诊卡号 2、医保卡号）
        /// </summary>
        public string IndexType { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public int IsDelete { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModDate { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModUser { get; set; }
    }
    public class Db_UserIndexMapper : EntityTypeConfiguration<Db_UserIndex>
    {
        public Db_UserIndexMapper()
        {
            ToTable("FT_UserIndex");
            HasKey(o => o.Id);
        }
    }
}
