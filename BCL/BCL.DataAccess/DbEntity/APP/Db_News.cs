using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_News
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 医院ID
        /// </summary>
        public string HospitalCode { get; set; }
        /// <summary>
        /// 资讯标题
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public String Author { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public String Summary { get; set; }
        /// <summary>
        /// 文本内容
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 资讯链接
        /// </summary>
        public String ContentUrl { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishTime { get; set; }
        /// <summary>
        /// 资讯图片
        /// </summary>
        public String Picture { get; set; }
        /// <summary>
        /// 顺序号
        /// </summary>
        public Int32? Order { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public String ModUser { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModDate { get; set; }
    }
    public class Db_NewsMap : EntityTypeConfiguration<Db_News>
    {
        public Db_NewsMap()
        {
            ToTable("APP_News");
            HasKey(k => k.Id);
        }
    }
}
