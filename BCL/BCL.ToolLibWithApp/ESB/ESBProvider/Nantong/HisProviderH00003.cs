using System;
using BCL.ToolLib;
using System.Linq;

namespace BCL.ToolLibWithApp.ESB.ESBProvider
{
    /// <summary>
    /// 南通妇幼
    /// </summary>
    public class HisProviderH00003 : HisProviderOfETrackInfo
    {
        internal static WebServiceAgent _HISClient2 = null;
        internal static WebServiceAgent _HISClient3 = null;
        public override string Business(params object[] args)
        {
            if (_HISClient == null)
                _HISClient = new WebServiceAgent("HisUrl".ConfigValue());
            if (_HISClient2 == null)
                _HISClient2 = new WebServiceAgent("HisUrl2".ConfigValue());
            if (_HISClient3 == null)
                _HISClient3 = new WebServiceAgent("HisUrl3".ConfigValue());
            return OnBusiness(o =>
            {
                if (args.Contains("2"))
                {
                    var x = _HISClient2.InvokeNoKey(o[0].ToString(), o[1].ToString());
                    if (x.ToString().IsNullOrEmptyOfVar())
                        throw new Exception("HIS错误:" + x.ToString());
                    return x.ToString();
                }
                else if (args.Contains("3"))
                {
                    var x = _HISClient3.InvokeNoKey(o[0].ToString(), o[1].ToString());
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
