using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess
{
    /// <summary>
    /// 商户列表
    /// </summary>
    public class Db_App : Db_Base
    {
        /// <summary>
        /// 应用代码
        /// </summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 应用名称
        /// </summary>
        public string AppName { get; set; }
        /// <summary>
        /// 医院代码
        /// </summary>
        public string HosCode { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HosName { get; set; }
        /// <summary>
        /// 开发商代码
        /// </summary>
        public string DevCode { get; set; }
        /// <summary>
        /// 开发商名称
        /// </summary>
        public string DevName { get; set; }
        /// <summary>
        /// 开发商密钥
        /// </summary>
        public string DevKey { get; set; }
        /// <summary>
        /// 途径种类
        /// </summary>
        public string BusKind { get; set; }
        /// <summary>
        /// 途径值
        /// </summary>
        public string BusValue { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public int Active { get; set; }
        /// <summary>
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
    }
    public class Db_AppMapper : EntityTypeConfiguration<Db_App>
    {
        public Db_AppMapper()
        {
            ToTable("UT_App");
            HasKey(o => o.Id);
        }
    }
}
