using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 数据权限视图类
 * Hui
 * 2017-8-29
 * 
 */
namespace BCL.DataAccess
{
    public class Db_V_DataPermit 
    {
        public string HosId { get; set; }

        public string HosCode { get; set; }

        public string HosName { get; set; }

        public string UserId { get; set; }
    }

    public class Db_V_DataPermitMapper : EntityTypeConfiguration<Db_V_DataPermit>
    {
        public Db_V_DataPermitMapper()
        {
            ToTable("v_user_datapermit");
            HasKey(o => o.HosId);
        }
    }

    public class Db_User_DataPermit
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
    }
}
