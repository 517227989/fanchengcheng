﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity.VAcc
{
    public class UPPReqModify : UPPReqBase
    {
        public string UserNo { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Birthday { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string IsBindBank { get; set; }
    }
    public class UPPResModify : UPPResBase
    {
    }
}
