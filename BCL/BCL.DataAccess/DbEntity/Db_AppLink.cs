using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess
{
    public class Db_AppLink : Db_Base
    {
        public int Mode { get; set; }
        public string Name { get; set; }
        public string AppCode { get; set; }
        public string Url { get; set; }
        public string AppId { get; set; }
        public string PubKey { get; set; }
        public string PriKey { get; set; }
        public string Key { get; set; }
        public string MchId { get; set; }
        public string CertPath { get; set; }
        public string PCode { get; set; }
        public string IconPath { get; set; }
        public int Active { get; set; }
    }
    public class Db_AppLinkMapper : EntityTypeConfiguration<Db_AppLink>
    {
        public Db_AppLinkMapper()
        {
            ToTable("UT_AppLink");
            HasKey(o => o.Id);
        }
    }
}
