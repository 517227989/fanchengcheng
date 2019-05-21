using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.XAI.Entity
{
    public class XAIReqBase
    {
        public string AppCode { get; set; }
        public string Channel { get; set; }
        public string ReqTime { get; set; }
        public string TermCode { get; set; }
        public string Args { get; set; }
        public string Kind { get; set; }
        public int RowId { get; set; }
    }
    public class XAIResBase
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public string UserId { get; set; }
        public string PaperWorkNo { get; set; }
        public string PhoneNo { get; set; }
        public UserInfo UserInfo { get; set; }
        public List<UserIndexInfo> Indexs { get; set; }
        public List<ImageInfo> Images { get; set; }
    }
    public class XAIBizResBase
    {
        public string Code { get; set; }
        public string Desc { get; set; }
    }

    public class XAIReqBaseJson
    {
        public string AppCode { get; set; }
        public string Channel { get; set; }
        public string ReqTime { get; set; }
        public string TermCode { get; set; }
        public XAIReqArgsJson Args { get; set; }
        public string Kind { get; set; }
        public int RowId { get; set; }
    }

    public class XAIReqArgsJson
    {
        public List<ImageInfo> Images { get; set; }
        public UserInfo UserInfo { get; set; }
        public string UserId { get; set; }
        public string Image { get; set; }
        public string GroupId { get; set; }
        public string HospitalId { get; set; }
        public string FaceToken { get; set; }
        public List<UserIndexInfo> Indexs { get; set; }
    }
}
