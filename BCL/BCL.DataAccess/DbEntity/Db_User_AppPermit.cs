using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
/*
 * 用户系统权限
 */
namespace BCL.DataAccess
{
    public class Db_User_AppPermit
    {

        /// <summary>
        /// 系统ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 系统图标
        /// </summary>
        public string Icon { get; set; }
    }

    public class Db_User_AppPermitMapper : EntityTypeConfiguration<Db_User_AppPermit>
    {
        public Db_User_AppPermitMapper()
        {
            ToTable("v_user_apppermit");
            HasKey(o => o.AppId);
        }
    }
}
