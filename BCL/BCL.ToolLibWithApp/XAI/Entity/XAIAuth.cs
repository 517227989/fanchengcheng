using System.Collections.Generic;

namespace BCL.ToolLibWithApp.XAI.Entity
{
    public class XAIReqAuth
    {
        public List<ImageInfo> Images { get; set; }
        public UserInfo UserInfo { get; set; }
        public string UserId { get; set; }
    }
    public class XAIResAuth : XAIBizResBase
    {
        public string AuthId { get; set; }
        public string UserId { get; set; }
        public string PaperWorkNo { get; set; }
        public string PhoneNo { get; set; }
        public List<string> FaceTokenList { get; set; }
    }
    public class UserInfo
    {
        public string PhoneNo { get; set; }
        public string PaperWorkNo { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Nature { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
    }
    public class ImageInfo
    {
        public string Kind { get; set; }
        public string Image { get; set; }
        public string ImageId { get; set; }
    }
}
