using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
   public class Db_V_Menu
    {
        public String Group_Id { get; set; }
        public String Menu_Id { get; set; }
        public String Menu_Name { get; set; }
    }
    public class Db_V_MenuMapper : EntityTypeConfiguration<Db_V_Menu>
    {
        public Db_V_MenuMapper()
        {
            ToTable("V_Menu");
            HasKey(k => k.Group_Id);
        }
    }
}
