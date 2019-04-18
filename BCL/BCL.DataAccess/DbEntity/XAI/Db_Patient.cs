using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.XAI
{
    /// <summary>
    /// 病人表
    /// </summary>
    public class Db_Patient
    {
        public int Id { get; set; }
        /// <summary>
        /// 认证业务号
        /// </summary>
        public string AuthId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 主索引
        /// </summary>
        public string Empi { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNo { get; set; }
        /// <summary>
        /// 性别 '男' '女' '未知'
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string Natrue { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string PaperworkType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string PaperworkNo { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public int IsDetele { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModDate { get; set; }
    }
    public class Db_PatientMapper : EntityTypeConfiguration<Db_Patient>
    {
        public Db_PatientMapper()
        {
            ToTable("FT_Patient");
            HasKey(o => o.Id);
        }
    }
}
