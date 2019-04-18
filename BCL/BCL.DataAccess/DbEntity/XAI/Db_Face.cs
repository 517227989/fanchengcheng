using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.XAI
{
    /// <summary>
    /// 人脸表
    /// </summary>
    public class Db_Face
    {
        public int Id { get; set; }
        /// <summary>
        /// 认证业务号
        /// </summary>
        public string AuthId { get; set; }
        /// <summary>
        /// 应用代码
        /// </summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 图像id
        /// </summary>
        public string ImageId { get; set; }
        /// <summary>
        /// 图像类型 BASE64、URL、FACE_TOKEN
        /// </summary>
        public string ImageType { get; set; }
        /// <summary>
        /// 人脸的类型 LIVE生活照、IDCARD二代身份证内置芯片中的人像照片
        /// </summary>
        public string FaceType { get; set; }
        /// <summary>
        /// 云端返回人脸唯一id
        /// </summary>
        public string FaceToken { get; set; }
        /// <summary>
        /// AI云端的appid
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// AI云端的组id
        /// </summary>
        public string GroupId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户信息 json
        /// </summary>
        public string UserInfo { get; set; }
        /// <summary>
        /// 人脸位置 左
        /// </summary>
        public string LocationLeft { get; set; }
        /// <summary>
        /// 人脸位置 上
        /// </summary>
        public string LocationTop { get; set; }
        /// <summary>
        /// 人脸位置 宽
        /// </summary>
        public string LocationWidth { get; set; }
        /// <summary>
        /// 人脸位置 高
        /// </summary>
        public string LocationHeight { get; set; }
        /// <summary>
        /// 人脸位置 翻转角度
        /// </summary>
        public string LocationRotaion { get; set; }
        /// <summary>
        /// 图片保存在磁盘地址（不一定存）
        /// </summary>
        public string ImgSaveUrl { get; set; }
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
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModUser { get; set; }
    }
    public class Db_FaceMapper : EntityTypeConfiguration<Db_Face>
    {
        public Db_FaceMapper()
        {
            ToTable("FT_Face");
            HasKey(o => o.Id);
        }
    }
}
