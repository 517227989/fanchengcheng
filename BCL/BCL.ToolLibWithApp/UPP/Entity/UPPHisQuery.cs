using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity
{
    public class UPPReqHisQuery
    {
        public string ResNo { get; set; }
        public string ReqNo { get; set; }
    }
    public class UPPResHisQuery
    {
        public string HisIsSuccess { get; set; }
        public string SupplementData { get; set; }
        public string ReqNo { get; set; }
        public string Mode { get; set; }
    }
    public class ReqGetHospitalBill
    {
        public string HospitalId { get; set; }
        public string RollDate { get; set; }
        public string ChannelId { get; set; }
    }
    public class ResGetHospitalBill
    {
        public string ResCode { get; set; }
        public string ResMsgs { get; set; }
        public string ResData { get; set; }
    }
}
