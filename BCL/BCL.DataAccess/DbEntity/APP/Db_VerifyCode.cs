using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_VerifyCode
    {
        /// <summary>
        /// Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public String PhoneNo { get; set; }
        /// <summary>
        /// 短信验证码
        /// </summary>
        public String VerifyCode { get; set; }
        /// <summary>
        /// 最后获取时间
        /// </summary>
        public DateTime LastTime { get; set; }
        /// <summary>
        /// 当日获取次数
        /// </summary>
        public Int32 DayCount { get; set; }
    }
    public class Db_VerifyCodeMap : EntityTypeConfiguration<Db_VerifyCode>
    {
        public Db_VerifyCodeMap()
        {
            ToTable("APP_VerifyCode");
            HasKey(k => k.Id);
        }
    }
}
