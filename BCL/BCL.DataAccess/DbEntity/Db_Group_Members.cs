using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
/*
 * 权限分组 组内成员信息
 */
namespace BCL.DataAccess
{
    public class Db_Group_Members
    {
        public int Id { get; set; }

        public string GroupId { get; set; }

        public string UserId { get; set; }

        public string AppId { get; set; }

        public string OperCode { get; set; }

        public DateTime? OperDate { get; set; }

        public int? OrderNo { get; set; }
    }

    public class Db_Group_Members_Mapper : EntityTypeConfiguration<Db_Group_Members>
    {
        public Db_Group_Members_Mapper()
        {
            ToTable("upm_group_members");
            HasKey(o => o.Id);
        }
    }
}
