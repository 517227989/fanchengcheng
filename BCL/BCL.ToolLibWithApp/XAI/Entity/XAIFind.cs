using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.XAI.Entity
{
    public class XAIReqFind
    {
        public string Image { get; set; }
        public string GroupId { get; set; }
    }
    public class XAIResFind : XAIBizResBase
    {
        public string UserId { get; set; }
        /// <summary>
        /// 用户索引(对应HIS用户主索引)
        /// </summary>
        public string EmpId { get; set; }
    }
}
