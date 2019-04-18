using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_EmpiIndex
    {
        public String EmpiId { get; set; }
        public String Name { get; set; }
        public Int32 SexCode { get; set; }
        public DateTime Birthday { get; set; }
        public String PaperNum { get; set; }
        public String MobilePhone { get; set; }
        public String RelationEmpis { get; set; }
        public String OperId { get; set; }
        public DateTime OperDate { get; set; }
        public Int32 MatchFlag { get; set; }
        public Int32 MatchValue { get; set; }
        public Int32 MasterFlag { get; set; }
        public DateTime AddDate { get; set; }
    }
    public class Db_EmpiIndexMapper : EntityTypeConfiguration<Db_EmpiIndex>
    {
        public Db_EmpiIndexMapper()
        {
            ToTable("ST_EmpiIndex");
            HasKey(o => o.EmpiId);
        }
    }
}
