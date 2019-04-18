using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
/*
 * 用户权限 菜单视图,勾选与否等
 */
namespace BCL.DataAccess
{
    public class Db_V_Group_Permits
    {
        /// <summary>
        /// 
        /// </summary>
        public string MenuId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 父类ID
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FinalFlag { get; set; }
        /// <summary>
        /// 分组ID
        /// </summary>
        public string GroupId { get; set; }
    }
    public class Db_V_Group_PermitsMapper : EntityTypeConfiguration<Db_V_Group_Permits>
    {
        public Db_V_Group_PermitsMapper()
        {
            ToTable("v_group_permits");
            HasKey(o => o.MenuId);
        }
    }
}
