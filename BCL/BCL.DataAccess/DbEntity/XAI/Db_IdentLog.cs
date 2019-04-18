using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.XAI
{
    /// <summary>
    /// 人脸识别日志表
    /// </summary>
    public class Db_IdentLog
    {
        public int Id { get; set; }
        /// <summary>
        /// 图像id
        /// </summary>
        public string ImageId { get; set; }
        /// <summary>
        /// 图像类型 BASE64、URL、FACE_TOKEN
        /// </summary>
        public string ImageType { get; set; }
        /// <summary>
        /// 返回值
        /// </summary>
        public int ReturnCode { get; set; }
        /// <summary>
        /// 返回描述
        /// </summary>
        public string ReturnDesc { get; set; }
        /// <summary>
        /// 用户id 
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 主索引id 
        /// </summary>
        public string Empi { get; set; }
        /// <summary>
        /// 交易进入时间
        /// </summary>
        public DateTime TimeIn { get; set; }
        /// <summary>
        /// 交易返回时间
        /// </summary>
        public DateTime TimeOut { get; set; }
        /// <summary>
        /// 是否删除
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
    }
    public class Db_IdentLogMapper : EntityTypeConfiguration<Db_IdentLog>
    {
        public Db_IdentLogMapper()
        {
            ToTable("FT_IdentLog");
            HasKey(o => o.Id);
        }
    }
}
