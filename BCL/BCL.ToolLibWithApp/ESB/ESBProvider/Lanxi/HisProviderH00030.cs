using BCL.ToolLib;
using System;

namespace BCL.ToolLibWithApp.ESB.ESBProvider
{
    public class HisProviderH00030 : HisProvider
    {
        internal static WebServiceAgent _HISClient = new WebServiceAgent("HisUrl".ConfigValue());
        public override string Business(params object[] args)
        {
            return OnBusiness(o =>
            {
                var s = String.Empty;
                if (args[(args.Length - 1)].ToString() == "1")
                {
                    if ("HisUrl2".ConfigValue().IsNullOrEmptyOfVar())
                        throw new Exception("appSettings 缺少 HisUrl2 的值");
                    //return ToolsContainer.Post("HisUrl2".ConfigValue(), o[1].ToString());
                    return WebRequestAgent.Post("HisUrl2".ConfigValue(), o[1].ToString());
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
        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override string Push(params object[] args)
        {
            return OnBusiness(o=> {
                if (o == null)
                    throw new Exception("POST请求入参参数不能为空");
                return "PushUrl".ConfigValue().Post(o[0].ToString(),false, "application/json");
            },args);
        }
    }
}
