using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class Db_Users : Db_Base
    {
        public string UserId { get; set; }
        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string UserSex { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string UserPhone { get; set; }
        /// <summary>
        /// 用户电子邮件
        /// </summary>
        public string UserEmail { get; set; }
        /// <summary>
        /// 用户地址
        /// </summary>
        public string UserAddress { get; set; }
        /// <summary>
        /// 用户等级
        /// </summary>
        public string UserLevel { get; set; }
        public int State { get; set; }
        public string UserType { get; set; }
        public string HospitalId { get; set; }
        public string BranchId { get; set; }
        public string HospitalName { get; set; }
        public string HosShortName { get; set; }
    }
    public class Db_UsersMapper : EntityTypeConfiguration<Db_Users>
    {
        public Db_UsersMapper()
        {
            ToTable("UT_Users");
            HasKey(o => o.Id);
        }
    }
}
