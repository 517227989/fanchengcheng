using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_FunConfigGroup_FunItem
    {
        public Int32 Id { get; set; }
        public String GroupId { get; set; }
        public String Fun_Id { get; set; }
    }
    public class Db_FunConfigGroup_FunItemMapper : EntityTypeConfiguration<Db_FunConfigGroup_FunItem>
    {
        public Db_FunConfigGroup_FunItemMapper()
        {
            ToTable("CT_FunConfigGroup_FunItem");
            HasKey(o => o.Id);
        }
    }
}
