using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_JobLog
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string HospitalId { get; set; }
        public string TradeType { get; set; }
        public string ReqMsg { get; set; }
        public string ResMsg { get; set; }
        public string RetCode { get; set; }
        public DateTime ReqTime { get; set; }
        public DateTime? ResTime { get; set; }
        public int TradeState { get; set; }
        public int UploadState { get; set; }
    }
    public class Db_JobLogMapper : EntityTypeConfiguration<Db_JobLog>
    {
        public Db_JobLogMapper()
        {
            ToTable("AT_JobLog");
            HasKey(k => k.Id);
        }
    }
}
