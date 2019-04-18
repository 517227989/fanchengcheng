using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Sequence
    {
        public Int32 Id { get; set; }
        public String SequenceType { get; set; }
        public String SequenceName { get; set; }
        public Int32 MinValue { get; set; }
        public Int32 MaxValue { get; set; }
        public Int32 CurrValue { get; set; }
        public Int32 Seed { get; set; }
    }
    public class Db_SequenceMapper : EntityTypeConfiguration<Db_Sequence>
    {
        public Db_SequenceMapper()
        {
            ToTable("ST_Sequence");
            HasKey(h => h.Id);
        }
    }
}
