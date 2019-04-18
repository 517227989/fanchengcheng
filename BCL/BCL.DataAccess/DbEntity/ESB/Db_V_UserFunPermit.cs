using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_V_UserFunPermit
    {
        public string User_Id { get; set; }
        public string Group_Id { get; set; }
        public string Menu_Id { get; set; }
        public string Func_Id { get; set; }
        public string Func_Name { get; set; }
        public string Func_Url { get; set; }
    }
    public class Db_V_UserFunPermitMapper : EntityTypeConfiguration<Db_V_UserFunPermit>
    {
        public Db_V_UserFunPermitMapper()
        {
            ToTable("V_UserFunPermit");
            HasKey(k => k.Menu_Id);
        }
    }
}
