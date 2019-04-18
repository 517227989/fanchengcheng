using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
/*
 * 用户常用功能
 * 
 */
namespace BCL.DataAccess
{
    public class Db_User_HotMenus : Db_Base
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public string MenuId { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        ///菜单指向URL
        /// </summary>
        public string PathUrl { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// Url后的参数
        /// </summary>
        public string ParamVal { get; set; }
        /// <summary>
        /// 点击量
        /// </summary>
        public int TipCount { get; set; }
    }

    public class Db_User_HotMenusMapper : EntityTypeConfiguration<Db_User_HotMenus>
    {
        public Db_User_HotMenusMapper()
        {
            ToTable("v_user_hotmenus");
            HasKey(o => o.MenuId);
        }
    }


}
