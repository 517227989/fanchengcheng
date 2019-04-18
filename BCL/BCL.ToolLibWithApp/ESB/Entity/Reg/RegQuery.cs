using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Reg
{
    /*
     * 挂号查询
     */

    public class ExternalReqRegQuery : ExternalReqBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// 挂号Id
        /// </summary>
        public string RegId { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public string BeginDateTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDateTime { get; set; }

        /// <summary>
        /// 排班ID
        /// </summary>
        public string DayId { get; set; }
    }

    public class ExternalResRegQuery : ExternalResBase
    {
        public List<RegInfo> RegList { get; set; }
        public ExternalResRegQuery ()
        {
            RegList = new List<RegInfo>();
        }
    }
}
