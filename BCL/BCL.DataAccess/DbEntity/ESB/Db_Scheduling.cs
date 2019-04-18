using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Scheduling
    {
        /// <summary>
        /// 医院ID
        /// 新增用于保存数据库，区分各家医院
        /// </summary>
        public string HospitalId { get; set; }

        /// <summary>
        /// 日排班Id
        /// </summary>
        public string DayId { get; set; }

        /// <summary>
        /// 周排班Id
        /// </summary>
        public string WeekId { get; set; }

        /// <summary>
        /// 排班日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 排班科室代码
        /// </summary>
        public string DeptCode { get; set; }

        /// <summary>
        /// 排班科室名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 排班医生代码
        /// </summary>
        public string DoctorCode { get; set; }

        /// <summary>
        /// 排班医生名称
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 排班类别代码
        /// </summary>
        public string TypeCode { get; set; }

        /// <summary>
        /// 排班类别名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 排班班次
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 挂号金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 号源总数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 号源剩余数
        /// </summary>
        public int SurplusCount { get; set; }

        /// <summary>
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        /// 分院名称
        /// </summary>
        public string BranchName { get; set; }

    }
    public class Db_SchedulingMapper : EntityTypeConfiguration<Db_Scheduling>
    {
        public Db_SchedulingMapper()
        {
            ToTable("AT_Schedulings");
            HasKey(k => new { k.HospitalId, k.DayId, k.Time });
        }
    }
}
