using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Res
{
    /*
    * 挂号查询
    */

    public class ExternalReqResQuery : ExternalReqBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 预约Id
        /// </summary>
        public string ResId { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public string BeginDateTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDateTime { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCardNo { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string PaperWorkType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string PaperWorkNo { get; set; }
    }

    /*
    * 预约回应
    */
    public class ExternalResResQuery : ExternalResBase
    {
        public List<ResInfo> ResList { get; set; }
        public ExternalResResQuery()
        {
            ResList = new List<ResInfo>();
        }
    }
}
