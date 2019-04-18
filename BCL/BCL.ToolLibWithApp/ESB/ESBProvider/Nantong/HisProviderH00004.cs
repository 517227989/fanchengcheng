using BCL.ToolLib;
using System;
using System.Linq;

namespace BCL.ToolLibWithApp.ESB.ESBProvider.Nantong
{
    public class HisProviderH00004 : HisProviderOfETrackInfo
    {
        //南通中医院 检验查询用的是第三方 webservice ，需要在配置文件中添加一个 HisUrl2
        internal static WebServiceAgent _HISClient2 = null;
        public override string Business(params object[] args)
        {
            if (_HISClient == null)
                _HISClient = new WebServiceAgent("HisUrl".ConfigValue());
            if (_HISClient2 == null)
                _HISClient2 = new WebServiceAgent("HisUrl2".ConfigValue());
            return OnBusiness(o =>
            {
                var s = String.Empty;
                if (args.Contains("JY"))
                {
                    var x = _HISClient2.InvokeNoKey(o[0].ToString(), o[1].ToString());
                    if (x.ToString().IsNullOrEmptyOfVar())
                        throw new Exception("HIS错误:" + x.ToString());
                    return x.ToString();
                }
                else
                {
                    var x = _HISClient.InvokeNoKey(o[0].ToString(), o[1].ToString());
                    if (x.ToString().IsNullOrEmptyOfVar())
                        throw new Exception("HIS错误:" + x.ToString());
                    return x.ToString();
                }
            }, args);
        }
    }
}
