using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_RollAccSummary
    {
        public int Id { get; set; }
        public String HospitalId { get; set; }
        public String HospitalName { get; set; }
        public DateTime TradeDate { get; set; }
        public Decimal TradeAmount { get; set; }
        public Int32 TradeCount { get; set; }
        public Decimal PayAmount { get; set; }
        public Int32 PayCount { get; set; }
        public Decimal RefundAmount { get; set; }
        public Int32 RefundCount { get; set; }
        public Int32 State { get; set; }
        public Int32 Channel { get; set; }
    }
    public class Db_RollAccSummaryMapper : EntityTypeConfiguration<Db_RollAccSummary>
    {
        public Db_RollAccSummaryMapper()
        {
            ToTable("ST_RollAccSummary");
            HasKey(o => o.Id);
        }
    }
}
