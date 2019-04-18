using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_Visitors
    {
        /// <summary>
        /// Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 就诊人ID
        /// </summary>
        public String visitorId { get; set; }
        /// <summary>
        /// 就诊人姓名
        /// </summary>
        public String VisitorName { get; set; }
        /// <summary>
        /// 就诊人类型 0->可绑定就诊卡 1->不可绑定就诊卡
        /// </summary>
        public int VisitorType { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public String UserId { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 性别 1~男/2~女
        /// </summary>
        public Int32 Sex { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public String Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public String Email { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public String PaperWorkType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public String PaperWorkNum { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public String District { get; set; }
        /// <summary>
        /// 删除标识 0.正常,1.作废
        /// </summary>
        public int IsCancel { get; set; }
        /// <summary>
        /// 卡类型适用业务:0.通用,1.门诊,2.住院,3.无卡
        /// </summary>
        public int Type { get; set; }
    }
    public class Db_VistorsMap : EntityTypeConfiguration<Db_Visitors>
    {
        public Db_VistorsMap()
        {
            ToTable("APP_Visitors");
            HasKey(k => k.Id);
        }
    }
}
