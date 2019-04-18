using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCL.ToolLib;

namespace BCL.ToolLibWithApp.ESB.ESBProvider
{
    /// <summary>
    /// 广安市人民医院
    /// </summary>
    public class HisProviderH00040 : HisProvider
    {
        //使用静态模式,防止刷数据时频繁new出新的实例致内存溢出错误
        internal static WebServiceAgent _wsAgent = null;
        public override string Business(params object[] args)
        {
            return OnBusiness(o => {
                if (_wsAgent==null)
                {
                    _wsAgent= new WebServiceAgent("HisUrl".ConfigValue());
                }
                var x = _wsAgent.InvokeNoKey("invoke", new object[] { o[0].ToString(), "urid".ConfigValue(), "pwd".ConfigValue(), o[1].ToString() });
                if (x == null)
                    throw new Exception("HIS返回值为Null");
                return x.ToString();
            }, args);
        }
    }
}
