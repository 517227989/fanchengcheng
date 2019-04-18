using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.SSP
{
    /// <summary>
    /// 自助机机器信息
    /// </summary>
    public class Db_Machine2
    {
        /// <summary>
        /// 机器号(主键之一)
        /// </summary>
        public string TermId { get; set; }
        /// <summary>
        /// 医院ID(主键之一)
        /// </summary>
        public string HospitalId { get; set; }

        /// <summary>
        /// 机器组JSON
        /// </summary>
        public string GroupJsonData { get; set; }
        /// <summary>
        /// 机器组类型
        /// </summary>
        public string WebType { get; set; }

        public string OperCode { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
    }

    public class Db_Machine2Mapper : EntityTypeConfiguration<Db_Machine2>
    {
        public Db_Machine2Mapper()
        {
            ToTable("st_n_machine");
            HasKey(w => new { w.TermId, w.HospitalId });
        }
    }
}
