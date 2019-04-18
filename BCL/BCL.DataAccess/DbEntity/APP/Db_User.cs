using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_AppUser
    {
        /// <summary>
        /// Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public String UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public String NickName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public String PassWord { get; set; }
        /// <summary>
        /// 是否注册 0~未注册/1~已注册
        /// </summary>
        public Int32 IsRegister { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public String Phone { get; set; }
        /// <summary>
        /// 头像位置
        /// </summary>
        public String Logo { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 设备Code 唯一编码
        /// </summary>
        public String DeviceImei { get; set; }
        /// <summary>
        /// 推送客户Id
        /// </summary>
        public String ClientId { get; set; }
        /// <summary>
        /// 短信验证码
        /// </summary>
        public String NoteCode { get; set; }
        /// <summary>
        /// 授权码
        /// </summary>
        public String Token { get; set; }
        /// <summary>
        /// 默认就诊人id
        /// </summary>
        public String DefaultVisitor { get; set; }
        /// <summary>
        /// 开放平台类别 01 QQ 02微信 03小程序
        /// </summary>
        public String OpenPlatformType { get; set; }
        /// <summary>
        /// 开放平台ID
        /// </summary>
        public String OpenPlatFormId { get; set; }
        /// <summary>
        /// 省平台ID
        /// </summary>
        public String PrPtId { get; set; }

    }
    public class Db_AppUserMap : EntityTypeConfiguration<Db_AppUser>
    {
        public Db_AppUserMap()
        {
            ToTable("APP_User");
            HasKey(k => k.Id);
        }
    }
}
