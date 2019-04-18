using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_VisitorForHospital
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 就诊人Id
        /// </summary>
        public String VisitorId { get; set; }
        /// <summary>
        /// 医院代码
        /// </summary>
        public String HospitalId { get; set; }
        /// <summary>
        /// 分院代码
        /// </summary>
        public String BranchCode { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public String UserId { get; set; }

        /// <summary>
        /// 就诊人姓名
        /// </summary>
        public String VisitorName { get; set; }
        /// <summary>
        /// 患者院内Id
        /// </summary>
        public String NosocomialId { get; set; }
        /// <summary>
        /// 患者院内卡号1：身份证号
        /// </summary>
        public String NosocomialNo1 { get; set; }
        /// <summary>
        /// 患者院内卡号2：医保卡号
        /// </summary>
        public String NosocomialNo2 { get; set; }
        /// <summary>
        /// 患者院内卡号3：就诊卡号
        /// </summary>
        public String NosocomialNo3 { get; set; }
        /// <summary>
        /// 患者院内卡号4：电子健康卡二维码字符串
        /// </summary>
        public String NosocomialNo4 { get; set; }
        /// <summary>
        /// 患者院内卡号5：电子健康卡二维码图片
        /// </summary>
        public String NosocomialNo5 { get; set; }
        /// <summary>
        /// 患者院内卡号5：住院号
        /// </summary>
        public String NosocomialNo6 { get; set; }
        /// <summary>
        /// 保险类型:1.自费,2.医保,3.商保
        /// </summary>
        public Int32 InsuranceType { get; set; }
    }
    public class Db_VistorForHospitalMap : EntityTypeConfiguration<Db_VisitorForHospital>
    {
        public Db_VistorForHospitalMap()
        {
            ToTable("APP_VisitorForHospital");
            HasKey(k => k.Id);
        }
    }
}
