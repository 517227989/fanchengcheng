using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_PrintInfo
    {
        public int Id { get; set; }
        /// <summary>
        /// 医院Id
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 就诊介质
        /// </summary>
        public int PatientCardType { get; set; }
        /// <summary>
        /// 就诊介质卡号
        /// </summary>
        public string PatientCardNum { get; set; }
        /// <summary>
        /// 病人姓名,冗余存
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 打印模板编码
        /// </summary>
        public string TempCode { get; set; }
        /// <summary>
        /// 打印内容
        /// Json数据
        /// </summary>
        public string TempData { get; set; }
        /// <summary>
        /// 凭条类型:冗余存，可通过模板Code关联获取,取号凭条,挂号等
        /// </summary>
        public string TempType { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string TempSum { get; set; }
        /// <summary>
        /// 打印次数
        /// </summary>
        public int PrintCount { get; set; }
        /// <summary>
        /// 创建时间.插入时间
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 自助机Id,备用，可不填
        /// </summary>
        public string KioskId { get; set; }
        /// <summary>
        /// 操作员工号
        /// </summary>
        public string OperCode { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
    public class Db_PrintInfoMapper : EntityTypeConfiguration<Db_PrintInfo>
    {
        public Db_PrintInfoMapper()
        {
            ToTable("At_PrintInfo");
            HasKey(k => new { k.Id });
        }
    }
}
