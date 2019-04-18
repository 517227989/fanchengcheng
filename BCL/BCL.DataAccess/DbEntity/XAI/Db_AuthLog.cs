using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.XAI
{
    /// <summary>
    /// 认证验证日志表
    /// </summary>
    public class Db_AuthLog 
    {
        public int Id { get; set; }
        /// <summary>
        /// 认证业务号
        /// </summary>
        public string AuthID { get; set; }
        /// <summary>
        /// 应用代码
        /// </summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 图像id
        /// </summary>
        public string FaceImageId { get; set; }
        /// <summary>
        /// 图像类型 BASE64、URL、FACE_TOKEN
        /// </summary>
        public string FaceImageType { get; set; }
        /// <summary>
        /// 图像id
        /// </summary>
        public string PaperworkImageId { get; set; }
        /// <summary>
        /// 图像类型 BASE64、URL、FACE_TOKEN
        /// </summary>
        public string PageworkImageType { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string PaperworkType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string PaperworkNo { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNo { get; set; }
        /// <summary>
        /// 传入消息
        /// </summary>
        public string MessageIn { get; set; }
        /// <summary>
        /// 回复消息
        /// </summary>
        public string MessageOut { get; set; }
        /// <summary>
        /// 返回值
        /// </summary>
        public int ReturnCode { get; set; }
        /// <summary>
        /// 返回描述
        /// </summary>
        public string ReturnDesc { get; set; }
        /// <summary>
        /// 交易传入时间
        /// </summary>
        public DateTime InTime { get; set; }
        /// <summary>
        /// 交易传出时间
        /// </summary>
        public DateTime OutTime { get; set; }
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
    }
    public class Db_AuthLogMapper : EntityTypeConfiguration<Db_AuthLog>
    {
        public Db_AuthLogMapper()
        {
            ToTable("FT_AuthLog");
            HasKey(o => o.Id);
        }
    }
}
