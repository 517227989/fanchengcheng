using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLib
{
    public class RequestWsProvider<K>
    {
        /// <summary>
        /// 请求客户端
        /// </summary>
        public K ReqClient = default(K);
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bindName"></param>
        public RequestWsProvider(String bindName = null)
        {
            ReqClient = CreateService<K>(String.IsNullOrEmpty(bindName) ? ("H" + "HospitalId".ConfigValue()) : bindName);
        }
        /// <summary>
        /// 创建服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bindName"></param>
        /// <returns></returns>
        public T CreateService<T>(String bindName)
        {
            return new ChannelFactory<T>(bindName).CreateChannel();
        }
    }
}
