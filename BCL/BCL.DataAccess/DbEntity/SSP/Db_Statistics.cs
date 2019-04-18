using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.SSP
{
    /// <summary>
    /// 自助机产品加入使用量统计功能
    /// </summary>
    public class Db_Statistics
    {        
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 统计记录Id
        /// </summary>
        public string StatisticId { get; set; }
        /// <summary>
        /// 设备id
        /// </summary>
        public string TermId { get; set; }
        /// <summary>
        /// 医院ID
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public string Business { get; set; }
        /// <summary>
        /// 业务目的:1.查询,2.操作
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// '患者性质,0：自费,1：医保,2：公费
        /// </summary>
        public string Nature { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 业务开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 业务结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 1完成 0未完成 2已读卡
        /// </summary>
        public int IsCompleted { get; set; }
        /// <summary>
        /// 网络地址
        /// </summary>
        public string MacAddress { get; set; }
        /// <summary>
        /// ip地址
        /// </summary>
        public string Ip { get; set; }
    }
}
