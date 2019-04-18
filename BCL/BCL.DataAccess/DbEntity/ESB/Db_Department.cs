using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Department
    {
        /// <summary>
        /// 医院ID
        /// </summary>
        public string DEPT_ID { get; set; }
        /// <summary>
        /// 医院代码
        /// </summary>
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string DEPT_NAME { get; set; }
        /// <summary>
        /// 分院编码
        /// </summary>
        public string BranchCode { get; set; }
        /// <summary>
        /// 分院名称
        /// </summary>
        public string BranchName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEPT_NAME_SHORT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEPT_DES { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PARENT_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DISTRICT_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KIND { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEPT_LEVEL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FINAL_FLAG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CLASS_USE_FLAG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CLASS_FINAL_FLAG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CLASS_DELETE_FLAG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string QUICK_CODE1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string QUICK_CODE2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string QUICK_CODE3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MODIFIED_BY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime MODIFIED_DATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ORDER_NO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEPT_ADDRESS { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public string Rank { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }
        /// <summary>
        /// 就医指南
        /// </summary>
        public string Guide { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// 背景图片
        /// </summary>
        public string BackPic { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 启用标志:1.启用,0.停用
        /// </summary>
        public string IsActive { get; set; }

    }
    public class Db_DepartmentMapper : EntityTypeConfiguration<Db_Department>
    {
        public Db_DepartmentMapper()
        {
            ToTable("CT_Department");
            HasKey(k => new { k.DEPT_ID, k.BranchCode });
        }
    }
}
