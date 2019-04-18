using System;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess.DbEntity.ESB
{
    /// <summary>
    /// 第三方接口科室
    /// </summary>
    public class Db_TPartyDept
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 医院Id
        /// </summary>
        public string HospitalId { get; set; }

        /// <summary>
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        /// 第三方接口类型
        /// </summary>
        public string TPartyType { get; set; }

        /// <summary>
        /// 医院科室代码
        /// </summary>
        public string DeptCode { get; set; }

        /// <summary>
        /// 第三方科室代码
        /// </summary>
        public string TPartyDeptCode { get; set; }

        /// <summary>
        /// 顺序号
        /// </summary>
        public int OrderNum { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModUser { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModDate { get; set; }
    }

    public class Db_TPartyDeptMap : EntityTypeConfiguration<Db_TPartyDept>
    {
        public Db_TPartyDeptMap()
        {
            ToTable("AT_TPartyDept");
            HasKey(k => k.Id);
        }
    }
}
