using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.XAI
{
    /// <summary>
    /// 图像表
    /// </summary>
    public class Db_Image
    {
        public int Id { get; set; }
        /// <summary>
        /// 图像id
        /// </summary>
        public string ImageId { get; set; }
        /// <summary>
        /// 图片base64
        /// </summary>
        public string Image { get; set; }
    }
    public class Db_ImageMapper : EntityTypeConfiguration<Db_Image>
    {
        public Db_ImageMapper()
        {
            ToTable("FT_Image");
            HasKey(o => o.Id);
        }
    }
}
