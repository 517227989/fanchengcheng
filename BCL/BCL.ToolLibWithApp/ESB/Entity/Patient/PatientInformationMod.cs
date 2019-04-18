using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Patient
{
    public class ExternalReqPatientInformationMod : ExternalReqBase
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PatientId { get; set; }
        public List<ModParamInfo> ModParamList;
        public ExternalReqPatientInformationMod()
        {
            ModParamList = new List<ModParamInfo>();
        }
    }

    public class ModParamInfo
    {
        /// <summary>
        /// 修改参数名
        /// </summary>
        public string ModParamName { get; set; }

        /// <summary>
        /// 修改参数值
        /// </summary>
        public string ModParamValue { get; set; }
    }

    /*
    * 患者信息修改
    */

    public class ExternalResPatientInformationMod : ExternalResBase
    {
    }
}
