using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess
{
    public class Db_Menus 
    {
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        public string DeleteFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LogFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderNo { get; set; }
        public DateTime ModDate { get; set; }
        public string OperCode { get; set; }
    }
    public class Db_MenusMapper : EntityTypeConfiguration<Db_Menus>
    {
        public Db_MenusMapper()
        {
            ToTable("UPM_Menus");
            HasKey(o => o.Id);
        }
    }
}
