using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.XAI
{
    public class XAIException : Exception
    {
        public XAIException(string exMsg)
        {

        }
        public XAIException(int exCode, string exMsg) : base(exMsg)
        {
            HResult = exCode;
        }
    }
}
