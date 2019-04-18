using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_HotDepts
    {
        /// <summary>
        /// 科室ID
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public String DeptName { get; set; }

        /// <summary>
        /// 顺序号
        /// </summary>
        public Int32 Order { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public String Logo { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public String ModUser { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModDate { get; set; }
        
    }
    public class Db_HotDeptsMap : EntityTypeConfiguration<Db_HotDepts>
    {
        public Db_HotDeptsMap()
        {
            ToTable("APP_HotDepts");
            HasKey(k => k.Id);
        }
    }
}
