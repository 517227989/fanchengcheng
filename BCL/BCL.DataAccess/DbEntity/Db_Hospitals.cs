using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess
{
    /// <summary>
    /// 医院列表
    /// </summary>
    public class Db_Hospitals : Db_Base
    {
        /// <summary>
        /// 医院Id
        /// </summary>
        public string HosId { get; set; }
        /// <summary>
        /// 医院代码
        /// </summary>
        public string HosCode { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HosName { get; set; }
        /// <summary>
        /// 医院等级
        /// 0:未说明等级
        /// 1:一级
        /// 1-1:一级甲等
        /// 1-2:一级乙等
        /// 1-3:一级丙等
        /// </summary>
        public string HosLevel { get; set; }
        /// <summary>
        /// 医院种类
        /// </summary>
        public string HosKind { get; set; }
        /// <summary>
        /// 输入码1
        /// </summary>
        public string ICode1 { get; set; }
        /// <summary>
        /// 输入码2
        /// </summary>
        public string ICode2 { get; set; }
        /// <summary>
        /// 作废标识
        /// </summary>
        public int IsEnable { get; set; }
    }
    public class Db_HospitalsMapper : EntityTypeConfiguration<Db_Hospitals>
    {
        public Db_HospitalsMapper()
        {
            ToTable("upm_Hospitals");
            HasKey(o => o.Id);
        }
    }
}
