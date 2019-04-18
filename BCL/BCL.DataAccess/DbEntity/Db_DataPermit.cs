using BCL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 数据权限_实体
 * 
 */
namespace BCL.DataAccess
{
    public class Db_DataPermit 
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string HospitalId { get; set; }
        public string OperCode { get; set; }
        public DateTime? OperDate { get; set; }
        public string Type { get; set; }
    }

    public class Db_DataPermitMapper : EntityTypeConfiguration<Db_DataPermit>
    {
        public Db_DataPermitMapper()
        {
            ToTable("upm_datapermit");
            HasKey(o => o.Id);
        }
    }
}
