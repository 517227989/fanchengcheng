using BCL.ToolLib.Modules;
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Xml;

namespace BCL.ToolLib
{
    public class WebServiceAgent
    {
        private object wsAgent;
        private Type wsAgentType;
        private const string CODE_NAMESPACE = "Beyondbit.WebServiceAgent.Dynamic";

        public WebServiceAgent(string url)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(url);
                ServiceDescription sd = ServiceDescription.Read(reader);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, null, null);
                CodeNamespace cn = new CodeNamespace(CODE_NAMESPACE);
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                CSharpCodeProvider ccp = new CSharpCodeProvider();
                CompilerParameters cp = new CompilerParameters();
                CompilerResults cr = ccp.CompileAssemblyFromDom(cp, ccu);
                wsAgentType = cr.CompiledAssembly.GetTypes()[0];
                wsAgent = Activator.CreateInstance(wsAgentType);
            }
            catch (Exception e)
            {
                GC.Collect();
                LogModule.Error(e);
            }
        }

        public WebServiceAgent()
        {

        }

        public object[] Invoke(string methodName, params object[] args)
        {
            MethodInfo mi = wsAgentType.GetMethod(methodName);
            return this.Invoke(mi, args);
        }

        public object[] Invoke(MethodInfo method, params object[] args)
        {
            method.Invoke(wsAgent, args);
            return args;
        }

        public object InvokeNoKey(string methodName, params object[] args)
        {
            MethodInfo mi = wsAgentType.GetMethod(methodName);
            return this.InvokeNoKey(mi, args);
        }

        public object InvokeNoKey(MethodInfo method, params object[] args)
        {
            return method.Invoke(wsAgent, args);
        }

        public MethodInfo[] Methods { get { return wsAgentType.GetMethods(); } }
    }

    public class WebRequestAgent
    {
        /// <summary>
        /// https，post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="valData"></param>
        /// <returns></returns>
        public static string Post(string url, string valData)
        {
            try
            {
                string strURL = url;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
                ServicePointManager.DefaultConnectionLimit = 200;
                request.Method = "POST";
                //request.ContentType = "application/json";
                request.Accept = "application/json";
                request.ContentType = "application/json; charset=utf-8";
                //request.Timeout = 2400000;
                //byte[] payload = Encoding.UTF8.GetBytes(valData);
                //request.ContentLength = payload.Length;
                Stream writer = request.GetRequestStream();
                //writer.Write(payload, 0, payload.Length);
                StreamWriter myStreamWriter = new StreamWriter(writer, Encoding.GetEncoding("UTF-8"));
                myStreamWriter.Write(valData);
                myStreamWriter.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string result = string.Empty;
                string encoding = response.ContentEncoding;
                if (encoding == null || encoding.Length < 1)
                    encoding = "UTF-8";
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
                Modules.LogModule.Info("响应状态StatusCode：" + response.StatusCode);
                result = reader.ReadToEnd();
                reader.Close();
                return result;
            }
            catch (Exception ex)
            {
                Modules.LogModule.Info(url + "请求异常:" + ex.InnerException());
                throw ex;
            }

        }
    }
}