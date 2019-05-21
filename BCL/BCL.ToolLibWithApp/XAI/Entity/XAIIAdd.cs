using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.XAI.Entity
{
    public class XAIReqIAdd
    {
        public string UserId { get; set; }
        public List<UserIndexInfo> Indexs { get; set; }
        public string HospitalId { get; set; }
    }
    public class XAIResIAdd : XAIBizResBase
    {
    }
    public class UserIndexInfo
    {
        public string Index { get; set; }
        public string IndexType { get; set; }
    }
}
