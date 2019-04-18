using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_Resrecordes
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 预约记录ID
        /// </summary>
        public String ResId { get; set; }
        /// <summary>
        /// 医院代码
        /// </summary>
        public String HospitalId { get; set; }
        /// <summary>
        /// 分院代码
        /// </summary>
        public String BranchCode { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public String HospitalName { get; set; }
        /// <summary>
        /// 日排班Id
        /// </summary>
        public String DayId { get; set; }
        /// <summary>
        /// 类别ID
        /// </summary>
        public String TypeCode { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public String TypeName { get; set; }
        /// <summary>
        /// 科室ID
        /// </summary>
        public String DeptCode { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public String DeptName { get; set; }
        /// <summary>
        /// 医生ID
        /// </summary>
        public String DoctorCode { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public String DoctorName { get; set; }
        /// <summary>
        /// 就诊人ID
        /// </summary>
        public String VisitorId { get; set; }
        /// <summary>
        /// 诊人姓名
        /// </summary>
        public String VisitorName { get; set; }
        /// <summary>
        /// 预约挂号类型 1->预约 2->挂号
        /// </summary>
        public Int32 ResType { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 预约日期
        /// </summary>
        public DateTime ResDate { get; set; }
        /// <summary>
        /// 预约时间段 1：上午2：下午3：晚上
        /// </summary>
        public String ResTime { get; set; }
        /// <summary>
        /// 预约金额
        /// </summary>
        public Decimal ResCost { get; set; }
        /// <summary>
        /// 就诊状态 1：正常(未付费)2：正常(已付费)3：已取消4：已取号
        /// </summary>
        public String ResState { get; set; }
        /// <summary>
        /// 挂号序号
        /// </summary>
        public String Number { get; set; }
        /// <summary>
        /// 就诊地址
        /// </summary>
        public String VisitAddress { get; set; }
        /// <summary>
        /// 就诊时间段
        /// </summary>
        public String VisitTime { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 医院病人Id
        /// </summary>
        public String HISPatientId { get; set; }
        /// <summary>
        /// 挂号回传参数
        /// </summary>
        public String PostBackMSG { get; set; }

    }
    public class Db_ResrecordesMap : EntityTypeConfiguration<Db_Resrecordes>
    {
        public Db_ResrecordesMap()
        {
            ToTable("APP_Resrecordes");
            HasKey(k => k.Id);
        }
    }
}
