using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.XAI
{
    public class Db_FApp
    {
        public int Id { get; set; }
        public string AppCode { get; set; }
        public int AppKind { get; set; }
        public int AppKey { get; set; }
        public int AppSecret { get; set; }
        public int IsDelete { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime ModDate { get; set; }
    }
    public class Db_FAppMapper : EntityTypeConfiguration<Db_FApp>
    {
        public Db_FAppMapper()
        {
            ToTable("FT_App");
            HasKey(o => o.Id);
        }
    }
}
