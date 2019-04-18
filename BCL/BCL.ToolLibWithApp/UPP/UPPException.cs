using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP
{
    public class UPPException : Exception
    {
        public UPPException(string exMsg)
        {

        }
        public UPPException(int exCode, string exMsg) : base(exMsg)
        {
            HResult = exCode;
        }
    }
}
