using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess
{
    public class Db_Privileges : Db_Base
    {
        public string PrivilegeCode { get; set; }
        public string PrivilegeName { get; set; }
        public string RoleCode { get; set; }
        public string MenuCode { get; set; }
    }
    public class Db_PrivilegesMapper : EntityTypeConfiguration<Db_Privileges>
    {
        public Db_PrivilegesMapper()
        {
            ToTable("UT_Privileges");
            HasKey(o => o.Id);
        }
    }
}
