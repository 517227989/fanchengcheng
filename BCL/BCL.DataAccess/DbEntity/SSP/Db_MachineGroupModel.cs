using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.SSP
{
    /// <summary>
    /// 模块功能表
    /// </summary>
    public class Db_MachineGroupModel : Db_Base
    {        
        /// <summary>
        /// 模块编号(主键)
        /// </summary>
        public string ModelCode { get; set; }
        /// <summary>
        /// JSON名称 无实际意义
        /// </summary>
        public string JsonName { get; set; }
        /// <summary>
        /// JSON内容
        /// </summary>
        public string JsonData { get; set; }
    }

    public class Db_MachineGroupModelMapper : EntityTypeConfiguration<Db_MachineGroupModel>
    {
        public Db_MachineGroupModelMapper()
        {
            ToTable("st_n_model");
            HasKey(w => new { w.ModelCode });
        }
    }
}
