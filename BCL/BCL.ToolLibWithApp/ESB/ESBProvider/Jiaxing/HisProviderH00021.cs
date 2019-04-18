using BCL.ToolLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.ESBProvider
{
    public class HisProviderH00021 : HisProvider
    {
        internal IHisApplay _HISClient { get; set; }
        public HisProviderH00021()
        {
            if (_HISClient == null)
                _HISClient = new RequestWsProvider<IHisApplay>("H" + _HOSPITALID).ReqClient;
        }
        public override string Business(params object[] args)
        {
            return OnBusiness(o =>
            {
                var x = _HISClient.RunService(o[0].ToString(), o[1].ToString());
                return x;
            }, args);
        }
    }
}
