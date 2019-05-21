using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.XAI.Entity
{
    public class XAIReqFMod
    {
        public string UserId { get; set; }
        public UserInfo UserInfo { get; set; }
        public string Image { get; set; }
        public string GroupId { get; set; }
    }
    public class XAIResFMod : XAIBizResBase
    {
        public string FaceToken { get; set; }
        public string LocationLeft { get; set; }
        public string LocationTop { get; set; }
        public string LocationWidth { get; set; }
        public string LocationHeight { get; set; }
        public string LocationRotaion { get; set; }
    }
}
