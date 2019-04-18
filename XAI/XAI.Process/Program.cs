using BCL.ToolLib;
using BCL.ToolLib.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace XAI.Process
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                HostFactory.Run(o =>
                {
                    o.Service<RESTfulAPIService>();
                    o.UseLinuxIfAvailable();
                    o.RunAsLocalSystem();
                    o.EnablePauseAndContinue();
                    o.StartAutomatically();
                    o.SetDescription("统一人脸平台服务");
                    o.SetDisplayName(string.Format("XAI.ProcessAPI_{0}.exe", "Port".ConfigValue("990")));
                    o.SetServiceName(string.Format("XAIServiceAPI_{0}", "Port".ConfigValue("990")));
                });
            }
            catch (Exception ex)
            {
                LogModule.Error(ex);
                throw ex;
            }
        }
    }
}
