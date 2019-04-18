using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.APP
{
    public class Db_HospitalConfig
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 医院代码
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }
        /// <summary>
        /// 支持服务代码  1->预约挂号 2->门诊缴费 3->排队叫号 4->检查检验报告单 5->取报告 6->住院 7->医院简介 8->医院公告
        /// </summary>
        public string SupportCode { get; set; }
        /// <summary>
        /// 支持服务名称
        /// </summary>
        public string SupportName { get; set; }
        /// <summary>
        /// 支持服务图片
        /// </summary>
        public string SupportPic { get; set; }
        /// <summary>
        /// 支持服务说明
        /// </summary>
        public string SupportRemarks { get; set; }
        /// <summary>
        /// 0->医院服务 1->固定服务 2->界面功能
        /// </summary>
        public int SupportType { get; set; }
        /// <summary>
        /// 0->停用 1->正常 2->即将开通
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 操作员工号
        /// </summary>
        public string OperCode { get; set; }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 服务类型 0->门诊 1->住院 2->综合
        /// </summary>
        public int GroupType { get; set; }
    }
    public class Db_HospitalConfigMap : EntityTypeConfiguration<Db_HospitalConfig>
    {
        public Db_HospitalConfigMap()
        {
            ToTable("APP_HospitalConfig");
            HasKey(k => k.Id);
        }
    }
}
