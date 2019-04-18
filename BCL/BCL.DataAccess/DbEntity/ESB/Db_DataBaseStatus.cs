using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_DataBaseStatus
    {
        public string Variable_name { get; set; }
        public string Value { get; set; }
    }
    public class Db_DataBaseStatusMapper : EntityTypeConfiguration<Db_DataBaseStatus>
    {
        public Db_DataBaseStatusMapper()
        {
            //ToTable("");
        }
    }
}
