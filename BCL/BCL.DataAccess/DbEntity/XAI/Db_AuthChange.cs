using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.XAI
{
    public class Db_AuthChange
    {
        public int Id { get; set; }
        public string AuthIdOld { get; set; }
        public string AuthIdNew { get; set; }
        public string UserId { get; set; }
        public DateTime ModDate { get; set; }
    }
    public class Db_AuthChangeMapper : EntityTypeConfiguration<Db_AuthChange>
    {
        public Db_AuthChangeMapper()
        {
            ToTable("FT_AuthChange");
            HasKey(o => o.Id);
        }
    }
}
