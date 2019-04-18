using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
/*
 * 权限对应菜单明细
 */
namespace BCL.DataAccess
{
    public class Db_Group_Permit
    {
        public int Id { get; set; }
        public string GroupId { get; set; }
        public string menuId { get; set; }
        public string OperCode { get; set; }
        public DateTime? OperDate { get; set; }
        public string OperFlag { get; set; }
    }

    public class Db_Group_PermitMapper : EntityTypeConfiguration<Db_Group_Permit>
    {
        public Db_Group_PermitMapper()
        {
            ToTable("upm_group_permit");
            HasKey(o => o.Id);
        }
    }
}
