using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Group_Member
    {
        public String GROUP_ID { get; set; }
        public String USER_ID { get; set; }
        public String SYSTEM_FLAG { get; set; }
        public DateTime Modified_Date { get; set; }
        public String Modified_By { get; set; }
        public Int32 ORDER_NO { get; set; }
    }
    public class Db_Group_MemberMapper : EntityTypeConfiguration<Db_Group_Member>
    {
        public Db_Group_MemberMapper()
        {
            ToTable("CT_Group_Member");
            HasKey(k => new { k.GROUP_ID, k.USER_ID });
        }
    }
}
