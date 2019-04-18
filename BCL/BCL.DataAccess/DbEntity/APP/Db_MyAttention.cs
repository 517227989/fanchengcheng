using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_MyAttention
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public String UserId { get; set; }
        /// <summary>
        /// 关注时间
        /// </summary>
        public DateTime AttentionTime { get; set; }
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
        /// 科室代码
        /// </summary>
        public String DeptCode { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public String DeptName { get; set; }
        /// <summary>
        /// 医生代码
        /// </summary>
        public String DoctorCode { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public String DoctorName { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public String Logo { get; set; }
        /// <summary>
        /// 类型 1-医院 2-科室 3医生
        /// </summary>
        public String Type { get; set; }
        /// <summary>
        /// 删除标识 0.正常,1.取消
        /// </summary>
        public int IsCancel { get; set; }
        /// <summary>
        /// 取消时间
        /// </summary>
        public DateTime CancelTime { get; set; }
        
    }
    public class Db_MyAttentionMap : EntityTypeConfiguration<Db_MyAttention>
    {
        public Db_MyAttentionMap()
        {
            ToTable("APP_MyAttention");
            HasKey(k => k.Id);
        }
    }
}
