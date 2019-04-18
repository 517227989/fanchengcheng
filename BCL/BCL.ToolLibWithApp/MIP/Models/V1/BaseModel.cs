using BCL.ToolLib;
using BCL.ToolLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.MIP.Models.V1
{
    public class BaseModel
    {
        public BaseModel()
        {
            ResCode = ToolLib.Enums.ResCode.交易成功.ToInt().ToString();
            ResMsg = ToolLib.Enums.ResCode.交易成功.ToString();
        }
        /// <summary>
        /// 患者索引
        /// </summary>
        public string Index { get; set; }
        /// <summary>
        /// 病人类别
        /// </summary>
        public string PCode { get; set; }
        /// <summary>
        /// 结算Id
        /// </summary>
        public string BillId { get; set; }
        public string VisitNo { get; set; }
        /// <summary>
        /// 是否生成订单
        /// </summary>
        public string IsOrder { get; set; }
        /// <summary>
        /// 操作工号
        /// </summary>
        public string OperCode { get; set; }
        /// <summary>
        /// 操作姓名
        /// </summary>
        public string OperName { get; set; }
        /// <summary>
        /// 对账流水
        /// </summary>
        public string ReconNo { get; set; }
        /// <summary>
        /// 终端编号
        /// </summary>
        public string TermCode { get; set; }
        public string CArgs { get; set; }
        /// <summary>
        /// 返回代码
        /// </summary>
        public string ResCode { get; set; }
        /// <summary>
        /// 返回参数
        /// </summary>
        public string ResMsg { get; set; }
    }
    public class BngBaseModel : BaseModel
    { 
    }
    public class EndBaseModel : BaseModel
    {
    }
}
