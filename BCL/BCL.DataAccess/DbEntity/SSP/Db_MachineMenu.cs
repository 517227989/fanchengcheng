using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.SSP
{
    /// <summary>
    /// 机器信息下有多少菜单实体
    /// </summary>
    public class Db_MachineMenu
    {        /// <summary>
        /// 机器号(主键之一)
        /// </summary>
        public string TermId { get; set; }
        /// <summary>
        /// 医院ID(主键之一)
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 菜单页编号(主键之一)
        /// </summary>
        public string MenuCode { get; set; }
    }

    public class Db_MachineMenuMapper : EntityTypeConfiguration<Db_MachineMenu>
    {
        public Db_MachineMenuMapper()
        {
            ToTable("st_machine_menu");
            HasKey(w => new { w.TermId, w.HospitalId,w.MenuCode});
        }
    }
}
