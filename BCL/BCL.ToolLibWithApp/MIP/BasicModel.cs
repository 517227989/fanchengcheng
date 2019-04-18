using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.MIP.Models
{
    public class BasicModel
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        public string HGuid { get; set; }
        /// <summary>
        /// 交易种类
        /// </summary>
        public string HKind { get; set; }
        /// <summary>
        /// 区划代码
        /// </summary>
        public string DCode { get; set; }
        /// <summary>
        /// 医保类别
        /// </summary>
        public string PCode { get; set; }
        /// <summary>
        /// 渠道代码
        /// </summary>
        public string CCode { get; set; }
        /// <summary>
        /// 医院参数
        /// </summary>
        public string HArgs { get; set; }
        /// <summary>
        /// 医保参数
        /// </summary>
        public string MArgs { get; set; }
        /// <summary>
        /// 医保卡数据
        /// </summary>
        public string CArgs { get; set; }
        /// <summary>
        /// 返回代码
        /// </summary>
        public string ResCode { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string ResMsg { get; set; }
    }
}
