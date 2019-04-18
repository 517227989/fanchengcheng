using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess
{
    public class Db_Agreement: Db_Base
    {
        public string AppCode { get; set; }
        public string Mode { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public string PSNo { get; set; }
        public string AgreeNo { get; set; }
        public string PCode { get; set; }
        public string Uid { get; set; }
        public string LoginId { get; set; }
        public int Status { get; set; }
        public DateTime? ValidTime { get; set; }
        public DateTime? InvalidTime { get; set; }
        public string TermCode { get; set; }
        public string NotifyUrl { get; set; }
    }
    public class Db_AgreementMapper : EntityTypeConfiguration<Db_Agreement>
    {
        public Db_AgreementMapper()
        {
            ToTable("UT_Agreement");
            HasKey(o => o.Id);
        }
    }
}
