using BCL.ToolLibWithApp.ESB.Entity.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.InHospital
{
    /*
     * 住院登记查询
     */

    public class ExternalReqInHospitalBedQuery : ExternalReqBase
    {
        /// <summary>
        /// 病区代码
        /// </summary>
        public string WardCode { get; set; }
    }
    /// <summary>
    /// 住院登记查询
    /// </summary>
    public class ExternalResInHospitalBedQuery : ExternalResBase
    {
        public List<WardInfo> WardList { get; set; }
        
        public ExternalResInHospitalBedQuery()
        {
            WardList = new List<WardInfo>();
        }
    }

    public class WardInfo
    {
        /// <summary>
        /// 病区代码
        /// </summary>
        public string WardCode { get; set; }

        /// <summary>
        /// 病区名称
        /// </summary>
        public string WardName { get; set; }
        
        /// <summary>
        /// 床位明细
        /// </summary>
        public List<BedInfo> BedList { get; set; }

        public WardInfo()
        {
            BedList = new List<BedInfo>();
        }
    }

    public class BedInfo
    {

        /// <summary>
        /// 床位代码
        /// </summary>
        public string BedCode { get; set; }

        /// <summary>
        /// 床位名称
        /// </summary>
        public string BedName { get; set; }

    }
}
