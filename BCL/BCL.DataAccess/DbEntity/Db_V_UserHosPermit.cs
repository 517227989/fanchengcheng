using System.Data.Entity.ModelConfiguration;
/*
 * 数据权限已授权用户视图类
 * Hui
 * 2017-8-29
 * 
 */

namespace BCL.DataAccess
{
    public class Db_V_UserHosPermit
    {
        public string UserId { get; set; }

        public string UserName { get; set;}

        public string UserCode { get; set; }
    }


    public class Db_V_UserHosPermitMapper:EntityTypeConfiguration<Db_V_UserHosPermit>
    {
        public Db_V_UserHosPermitMapper()
        {
            ToTable("v_user_hospermit");
            HasKey(o => o.UserId);
        }
    }
}
