using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_FunConfigGroup
    {
        public Int32 GroupId { get; set; }
        public String GroupName { get; set; }
        public DateTime AddDate { get; set; }
        public String OperCode { get; set; }
        public String OperName { get; set; }
        public Int32 State { get; set; }
        public String SRM { get; set; }
        public String HospitalId { get; set; }
    }
    public class Db_FunConfigGroupMapper : EntityTypeConfiguration<Db_FunConfigGroup>
    {
        public Db_FunConfigGroupMapper()
        {
            ToTable("CT_FunConfigGroup");
            HasKey(k => k.GroupId);
        }
    }
}
