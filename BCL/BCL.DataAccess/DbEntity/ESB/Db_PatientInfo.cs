using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_PatientInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 患者住院Id
        /// </summary>
        public string PInHospitalId { get; set; }
        /// <summary>
        /// 操作人Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 医院Id
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 分院代码    
        /// </summary>
        public string BranchCode { get; set; }
        /// <summary>
        /// 住院Id
        /// </summary>
        public string InHospitalId { get; set; }
        /// <summary>
        /// 病案号
        /// </summary>
        public string RecordNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 住院日期
        /// </summary>
        public DateTime InHospitalDate { get; set; }
        /// <summary>
        /// 出院日期
        /// </summary>
        public DateTime? OutHospitalDate { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string PaperWorkType { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string PaperWorkNo { get; set; }
    }
    public class Db_PatientInfoMapper : EntityTypeConfiguration<Db_PatientInfo>
    {
        public Db_PatientInfoMapper()
        {
            ToTable("Mr_PatientInfo");
            HasKey(k => new { k.Id });
        }
    }
}
