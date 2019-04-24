using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.XAI.Entity
{
    public class XAIReqGetUserList
    {
        public string GroupId { get; set; }
    }
    public class XAIResGetUserList : XAIBizResBase
    {
        public List<string> UserIdList { get; set; }
    }

}
