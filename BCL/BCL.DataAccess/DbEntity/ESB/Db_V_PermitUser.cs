using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_V_PermitUser
    {
        public String User_Id { get; set; }
        public String User_No { get; set; }
        public String User_Name { get; set; }
        public String User_Sex { get; set; }
        public String User_Pwd { get; set; }
        public String Dept_Id { get; set; }
        public Int32 Delete_Flag { get; set; }
        public DateTime Delete_Date { get; set; }
        public String Default_Quick_Code { get; set; }
        public String Quick_Code1 { get; set; }
        public String Quick_Code2 { get; set; }
        public String Quick_Code3 { get; set; }
        public DateTime Modified_Date { get; set; }
        public String Modified_By { get; set; }
        public String NStationId { get; set; }
    }
    public class Db_V_PermitUserMapper : EntityTypeConfiguration<Db_V_PermitUser>
    {
        public Db_V_PermitUserMapper()
        {
            ToTable("V_PermitUser");
            HasKey(k => k.User_Id);
        }
    }
}
