using BCL.ToolLibWithApp.UPP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Face
{
    public class UPPReqFaceUserQuery
    {
        public string Code { get; set; }
    }
    public class UPPResFaceUserQuery : UPPBizResBase
    {
        public string Uid { get; set; }
        public string ImgUrl { get; set; }
        public string Name { get; set; }
        public string IDCardNo { get; set; }
    }
}
