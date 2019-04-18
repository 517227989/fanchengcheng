using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_ExceptionMessage
    {
        public int Id { get; set; }
        public string MessageId { get; set; }
        public string TradeType { get; set; }
        public string QueueName { get; set; }
        public string Message { get; set; }
        public string FailDetail { get; set; }
        public DateTime AddDate { get; set; }
    }
    public class Db_ExceptionMessageMapper : EntityTypeConfiguration<Db_ExceptionMessage>
    {
        public Db_ExceptionMessageMapper()
        {
            ToTable("ST_ExceptionMessage");
            HasKey(x => x.Id);
        }
    }
}
