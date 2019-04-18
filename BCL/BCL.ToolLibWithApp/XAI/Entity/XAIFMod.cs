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
        /// <summary>
        /// 行为标志  APPEND：追加(默认)       REPLACE：替换

        /// </summary>
        public string Action { get; set; }
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
