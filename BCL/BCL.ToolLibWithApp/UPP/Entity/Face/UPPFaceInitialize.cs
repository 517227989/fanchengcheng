using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Face
{
    public class UPPReqFaceInitialize
    {
        public string InitializeInfo { get; set; }
        public string Amount { get; set; }
        public string BizType { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
    }
    public class UPPResFaceInitialize : UPPBizResBase
    {
        public string FaceId { get; set; }
        public string FaceData { get; set; }
    }
}
