using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess
{
    public class Db_ReconcileConfig
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 医院代码
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }
        /// <summary>
        /// 分院名称
        /// </summary>
        public string BranchName { get; set; }
        /// <summary>
        /// 渠道种类E:外部渠道[指微信、支付宝等]I:内部渠道[指医院等]
        /// </summary>
        public string CKind { get; set; }
        /// <summary>
        /// 渠道代码
        /// </summary>
        public string CCode { get; set; }
        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }
        /// <summary>
        /// 账单明细过滤条件
        /// </summary>
        public string BillCondition { get; set; }
        /// <summary>
        /// 医院第三方请求信息
        /// </summary>
        public string RequestInfo { get; set; }
        /// <summary>
        /// 私钥
        /// </summary>
        public string PriKey { get; set; }
        /// <summary>
        /// 公钥
        /// </summary>
        public string PubKey { get; set; }
        /// <summary>
        /// FTP地址
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// FTP用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// FTP密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// FTP文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 调账单类型
        /// </summary>
        public Int32? BillType { get; set; }
        /// <summary>
        ///  是否启用 默认0启用
        /// </summary>
        public Int32 Active { get; set; }
        /// <summary>
        /// 操作员代码
        /// </summary>
        public string OperCode { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
    public class Db_ReconcileConfigMapper : EntityTypeConfiguration<Db_ReconcileConfig>
    {
        public Db_ReconcileConfigMapper()
        {
            ToTable("UPM_ReconcileConfig");
            HasKey(o => o.Id);
        }
    }
}
