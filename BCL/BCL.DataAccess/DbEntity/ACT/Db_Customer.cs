using System;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess.DbEntity.ACT
{
    public class Db_Customer
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// 用户类型 1：微信
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 工作单位
        /// </summary>
        public string Enterprise { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModUser { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModDate { get; set; }

        /// <summary>
        /// 其他信息
        /// </summary>
        public string OtherInfo { get; set; }

        /// <summary>
        /// APPId
        /// </summary>
        public string AppId { get; set; }
    }

    public class Db_CustomerMap : EntityTypeConfiguration<Db_Customer>
    {
        public Db_CustomerMap()
        {
            ToTable("at_customer");
            HasKey(k => k.Id);
        }
    }
}
