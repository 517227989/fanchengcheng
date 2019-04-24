using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.XAI.Entity
{
    public class XAIReqDeleteFace
    {
        public string UserId { get; set; }
        public string GroupId { get; set; }
        public string FaceToken { get; set; }
    }
    public class XAIResDeleteFace : XAIBizResBase
    {
    }
}
