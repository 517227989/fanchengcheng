using System;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess.DbEntity.APP
{
    /// <summary>
    /// 微信通知模板
    /// </summary>
    public class Db_NotifyTemplate
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
        /// 模板Id
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// 模板标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModUser { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModDate { get; set; }
    }
    public class Db_NotifyTemplateMap : EntityTypeConfiguration<Db_NotifyTemplate>
    {
        public Db_NotifyTemplateMap()
        {
            ToTable("APP_NotifyTemplate");
            HasKey(k => k.Id);
        }
    }
}
