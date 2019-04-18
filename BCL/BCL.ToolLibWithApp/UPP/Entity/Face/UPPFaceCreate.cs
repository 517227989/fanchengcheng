using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.Face
{
    public class UPPReqFaceCreate
    {
        public string FaceType { get; set; }
        public string FaceVal { get; set; }
        public string DeviceNum { get; set; }
    }
    public class UPPResFaceCreate : UPPBizResBase
    {
    }
}
