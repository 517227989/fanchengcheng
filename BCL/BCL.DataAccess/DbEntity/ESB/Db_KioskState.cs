using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Create By:Hui.Liu
 * Create Date:2017-11-01
 * Des:
 * 自助机状态
 */
namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_KioskState
    {
        public int Id { get; set; }
        /// <summary>
        /// 自助机ID
        /// </summary>
        public string KioskId { get; set; }
        /// <summary>
        /// 状态名
        /// </summary>
        public string StateKey { get; set; }
        /// <summary>
        /// 状态值
        /// </summary>
        public string StateValue { get; set; }
    }
    public class Db_KioskStateMapper : EntityTypeConfiguration<Db_KioskState>
    {
        public Db_KioskStateMapper()
        {
            ToTable("at_kioskstate");
            HasKey(k => new { k.Id });
        }
    }
}
