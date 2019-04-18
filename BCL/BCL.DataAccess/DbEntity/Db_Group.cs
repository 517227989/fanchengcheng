using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 权限分组实体
 */
namespace BCL.DataAccess
{
    public class Db_Group_UPP 
    {
        public int Id { get; set; }

        public string GroupId { get; set; }

        public string GroupName { get; set; }

        public string DeleteFlag { get; set; }

        public string OperCode { get; set; }

        public DateTime? OperDate { get; set; }

        public string AppId { get; set; }

        public string GroupType { get; set; }

        public string Srm { get; set; }
    }

    public class Db_GroupMapper : EntityTypeConfiguration<Db_Group_UPP>
    {
        public Db_GroupMapper()
        {
            ToTable("upm_group");
            HasKey(o => o.Id);
        }
    }
}
