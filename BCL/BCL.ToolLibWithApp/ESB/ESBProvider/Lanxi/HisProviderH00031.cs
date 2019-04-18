using BCL.ToolLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.ESBProvider
{
    public class HisProviderH00031 : HisProvider
    {
        internal static WebServiceAgent _HISClient = new WebServiceAgent("HisUrl".ConfigValue());
        public override string Business(params object[] args)
        {
            return OnBusiness(o =>
            {
                var s = String.Empty;
                if (args[(args.Length - 1)].ToString() == "1")
                {
                    //return ToolsContainer.Post("HisUrl2".ConfigValue("http://192.168.1.211:8081/zd.ashx"), o[1].ToString());
                    return WebRequestAgent.Post("HisUrl2".ConfigValue("http://192.168.1.211:8081/zd.ashx"), o[1].ToString());
                }
                else
                {
                    var x = _HISClient.Invoke("Etrack_ProcInterface", o[0].ToString(), s);
                    if (x[1].ToString().IsNullOrEmptyOfVar())
                        throw new Exception("HIS错误:" + x[1].ToString());
                    return x[1].ToString();
                }
            }, args);
        }
    }
}
