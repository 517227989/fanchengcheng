using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_TaskGroup
    {
        public int FailCount { get; set; }
        public int SuccessCount { get; set; }
        public int ExecuteCount { get; set; }
        public int ExecuteStatus { get; set; }
        public string AddOper { get; set; }
        public DateTime AddDate { get; set; }
        public int Active { get; set; }
        public string CronExpression { get; set; }
        public string JobValue { get; set; }
        public string JobKey { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string TriggerName { get; set; }
        public string Group { get; set; }
    }
    public class Db_TaskGroupMapper : EntityTypeConfiguration<Db_TaskGroup>
    {
        public Db_TaskGroupMapper()
        {
            ToTable("APP_TaskGroup");
            HasKey(o => o.Id);
        }
    }
}
