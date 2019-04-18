using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_FeedBack
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public String UserId { get; set; }

        /// <summary>
        /// 反馈内容
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public String Phone { get; set; }
            /// <summary>
        /// 反馈时间
        /// </summary>
        public DateTime FeedTime { get; set; }
        
    }
    public class Db_FeedBackMap : EntityTypeConfiguration<Db_FeedBack>
    {
        public Db_FeedBackMap()
        {
            ToTable("APP_FeedBack");
            HasKey(k => k.Id);
        }
    }
}
