using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqPatientUniCheck : ExternalReqBase
    {
        public String CardType { get; set; }
        public String CardInfo { get; set; }
        public String NStationId { get; set; }
        /// <summary>
        /// 1：医生暂停可报到 0：医生暂停不可报到  0:默认 
        /// </summary>
        [DefaultValue("0")]
        public string CoerceCheckFlag { get; set; }

    }
    public class ExternalResPatientUniCheck : ExternalResBase
    {
        public List<CheckInfo> CheckInfoList { get; set; }
    }
}
