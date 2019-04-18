using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Kiosk
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 医院代码
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 设备号
        /// </summary>
        public string KioskId { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string OperCode { get; set; }
    }
    public class Db_KioskMapper : EntityTypeConfiguration<Db_Kiosk>
    {
        public Db_KioskMapper()
        {
            ToTable("Ct_Kiosks");
            HasKey(k => new { k.Id, k.HospitalId, k.KioskId, k.OperCode });
        }
    }
}
