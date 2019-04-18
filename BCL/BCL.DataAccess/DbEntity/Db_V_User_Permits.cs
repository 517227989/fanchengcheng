using System;
using System.Data.Entity.ModelConfiguration;
/*
 * 
 */
namespace BCL.DataAccess
{
    public class Db_V_User_Permits
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string MenuId { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        public string MenuCode { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 父类ID
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 控制器地址
        /// </summary>
        public string PathUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OperCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ModDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FinalFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ParamVal { get; set; }
        /// <summary>
        /// 权限控制标识
        /// </summary>
        public string ControlFlag { get; set; }

        public string DeleteFlag { get; set; }

        public string LogFlag { get; set; }

        public int? OrderNo { get; set; }
    }

    public class Db_User_PermitsMapper : EntityTypeConfiguration<Db_V_User_Permits>
    {
        public Db_User_PermitsMapper()
        {
            ToTable("v_user_permits");
            HasKey(o => o.Id);
        }
    }
}
