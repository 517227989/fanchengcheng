using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess
{
    /// <summary>
    /// 开发商列表
    /// </summary>
    public class Db_Developers:Db_Base
    {
        /// <summary>
        /// 开发商代码
        /// </summary>
        public string DevCode { get; set; }
        /// <summary>
        /// 开发商名称
        /// </summary>
        public string DevName { get; set; }
        /// <summary>
        /// 开发商种类
        /// </summary>
        public string DevKind { get; set; }
        /// <summary>
        /// 输入码1
        /// </summary>
        public string ICode1 { get; set; }
        /// <summary>
        /// 输入码2
        /// </summary>
        public string ICode2 { get; set; }
    }
    public class Db_DevelopersMapper : EntityTypeConfiguration<Db_Developers>
    {
        public Db_DevelopersMapper()
        {
            ToTable("UT_Developers");
            HasKey(o => o.Id);
        }
    }
}
