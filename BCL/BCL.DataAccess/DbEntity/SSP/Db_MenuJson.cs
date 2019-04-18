using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.SSP
{
   public  class Db_MenuJson
    {
        /// <summary>
        /// 界面菜单ID 主键之一
        /// </summary>
        public string MenuCode { get; set; }

        /// <summary>
        /// JSON的ID 主键之一
        /// </summary>
        public int JsonId { get; set; }
        /// <summary>
        /// JSON的级别树 1为顶层
        /// </summary>
        public int JsonLevel { get; set; }
        /// <summary>
        /// 父JSON ID 只有当JsonLevel不为1时才会有值
        /// </summary>
        public int ParentJsonId { get; set; }
    }

    public class Db_MenuJsonMapper : EntityTypeConfiguration<Db_MenuJson>
    {
        public Db_MenuJsonMapper()
        {
            ToTable("st_menu_json");
            HasKey(w => new { w.MenuCode, w.JsonId,w.JsonLevel });
        }
    }
}
