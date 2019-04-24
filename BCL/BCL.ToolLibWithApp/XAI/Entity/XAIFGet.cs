using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.XAI.Entity
{
    public class XAIReqFGet
    {
        public string UserId { get; set; }
        public string GroupId { get; set; }
    }
    public class XAIResFGet:XAIBizResBase
    {
        public List<ImageInfo> Images { get; set; }
        public UserInfo UserInfo { get; set; }
        public List<UserIndexInfo> Indexs { get; set; }
    }
}
