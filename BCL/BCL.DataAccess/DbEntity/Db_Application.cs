using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

/*
 * 系统信息
 */
namespace BCL.DataAccess
{
    public class Db_Application
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string TypeId { get; set; }
        public string DeleteFlag { get; set; }
        public string Icon { get; set; }
        public int OrderNo { get; set; }
    }

    public class Db_ApplicationMapper : EntityTypeConfiguration<Db_Application>
    {
        public Db_ApplicationMapper()
        {
            ToTable("upm_application");
            HasKey(o => o.Id);
        }

    }
}
