using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess
{
    public class Db_Roles : Db_Base
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
    }
    public class Db_RolesMapper : EntityTypeConfiguration<Db_Roles>
    {
        public Db_RolesMapper()
        {
            ToTable("UT_Roles");
            HasKey(o => o.Id);
        }
    }
}
