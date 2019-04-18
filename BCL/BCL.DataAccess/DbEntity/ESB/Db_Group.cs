using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Group
    {
        public String GROUP_ID { get; set; }
        public String GROUP_NAME { get; set; }
        public String CLASS_ID { get; set; }
        public String GROUP_TYPE { get; set; }
        public String APP_ID { get; set; }
        public Int32 Delete_Flag { get; set; }
        public DateTime Delete_Date { get; set; }
        public String Quick_Code1 { get; set; }
        public String Quick_Code2 { get; set; }
        public String Quick_Code3 { get; set; }
        public DateTime Modified_Date { get; set; }
        public String Modified_By { get; set; }
    }
    public class Db_GroupMapper : EntityTypeConfiguration<Db_Group>
    {
        public Db_GroupMapper()
        {
            ToTable("CT_Group");
            HasKey(k => k.GROUP_ID);
        }
    }
}
