using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess
{
    public class Db_UserRoles : Db_Base
    {
        public string UserCode { get; set; }
        public string RoleCode { get; set; }
    }
    public class Db_UserRolesMapper : EntityTypeConfiguration<Db_UserRoles>
    {
        public Db_UserRolesMapper()
        {
            ToTable("UT_UserRoles");
            HasKey(o => o.Id);
        }
    }
}
