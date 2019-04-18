using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Face
{
    public class UPPReqFaceQuery
    {
        public string FToken { get; set; }
        public string BizType { get; set; }
    }
    public class UPPResFaceQuery : UPPBizResBase
    {
        public string Uid { get; set; }
        public string ImgStr { get; set; }
        public string Phone { get; set; }
    }
}
