using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_V_GMember
    {
        public String User_Id { get; set; }
        public String User_No { get; set; }
        public String User_Name { get; set; }
        public String User_Sex { get; set; }
        public String NStationId { get; set; }
        public String Group_Id { get; set; }
    }
    public class Db_V_GMemberMapper : EntityTypeConfiguration<Db_V_GMember>
    {
        public Db_V_GMemberMapper()
        {
            ToTable("V_GMember");
            HasKey(k => k.User_Id);
        }
    }
}
