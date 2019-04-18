using BCL.ToolLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.ESBProvider
{
    public class HisProviderH00037 : HisProvider
    {
        internal static WebServiceAgent _HISClient = new WebServiceAgent("HisUrl".ConfigValue());
        public override string Business(params object[] args)
        {
            return OnBusiness(o=> {
                var x = _HISClient.InvokeNoKey(o[0].ToString(), new object[] { o[1].ToString() });
                return x.ToString();
            },args);
        }
    }
}
