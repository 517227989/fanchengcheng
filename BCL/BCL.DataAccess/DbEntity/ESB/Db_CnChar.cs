using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_CnChar
    {
        public string Id { get; set; }
        public string CnChar { get; set; }
        public string Spell { get; set; }
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
    }
    public class Db_CnCharMapper : EntityTypeConfiguration<Db_CnChar>
    {
        public Db_CnCharMapper()
        {
            ToTable("CT_CnChar");
            HasKey(o => o.Id);
        }
    }
}
