using BCL.ToolLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.ESBProvider
{
    public class HisProviderH00020 : HisProvider
    {
        internal IHisApplay _HISClient { get; set; }
        internal static WebServiceAgent WS = null;
        public HisProviderH00020()
        {
            try
            {
                if (_HISClient == null)
                    _HISClient = new RequestWsProvider<IHisApplay>("H" + _HOSPITALID).ReqClient;
                if (WS == null)
                    WS = new WebServiceAgent("HisUrl".ConfigValue());
            }
            catch (Exception)
            {
            }
        }
        public override string Business(params object[] args)
        {
            return OnBusiness(o =>
            {
                if (args.Contains("SFYZ")) //身份验证
                {
                    var _Client = new RequestWsProvider<HealthCardService>("H" + _HOSPITALID + "_HCS").ReqClient;
                    var getAuthKey = args[0] as getAuthKey;
                    var res = _Client.getAuthKey(getAuthKey);
                    if (res != null)
                    {
                        if (res.@return != null)
                            return res.ToJson();
                    }
                    return null;
                }
                else if (args.Contains("JD")) //建档
                {
                    var _Client = new RequestWsProvider<HealthCardService>("H" + _HOSPITALID + "_HCS").ReqClient;
                    var syncCardInfo = args[0] as syncCardInfo;
                    var res = _Client.syncCardInfo(syncCardInfo);
                    if (res != null)
                    {
                        if (res.@return != null)
                            return res.ToJson();
                    }
                    return null;
                }
                else if (args.Contains("RWMCX")) //二维码查询
                {
                    var _Client = new RequestWsProvider<HealthCardService>("H" + _HOSPITALID + "_HCS").ReqClient;
                    var virIdCardVerify = args[0] as virIdCardVerify;
                    var res = _Client.virIdCardVerify(virIdCardVerify);
                    if (res != null)
                    {
                        if (res.@return != null)
                            return res.ToJson();
                    }
                    return null;
                }
                else
                {
                    var x = _HISClient.RunService(o[0].ToString(), o[1].ToString());
                    return x;
                }
            }, args);
        }
    }
}
