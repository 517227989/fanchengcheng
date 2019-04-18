using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
/*
 * 权限已分配用户
 */
namespace BCL.DataAccess
{
    public class Db_V_PermitUser_UPP
    {
        public string UserId { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }

        public string GroupId { get; set; }

    }

    public class Db_V_PermitUserMapper : EntityTypeConfiguration<Db_V_PermitUser_UPP>
    {
        public Db_V_PermitUserMapper()
        {
            ToTable("v_permituser");
            HasKey(o => o.UserId);
        }
    }

}
