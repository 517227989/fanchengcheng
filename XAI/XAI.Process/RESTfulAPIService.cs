using BCL.ToolLib;
using BCL.ToolLib.Modules;
using Mono.Unix;
using Mono.Unix.Native;
using Nancy;
using Nancy.Hosting.Self;
using System;
using Topshelf;

namespace XAI.Process
{
    public class RESTfulAPIService : ServiceControl, IDisposable
    {
        #region ServiceControl 成员
        protected NancyHost _host = null;
        public bool Start(HostControl hostControl)
        {
            try
            {
                HostNancy(_host);
            }
            catch (Exception ex)
            {
                LogModule.Error(ex);
                return false;
            }
            return true;
        }
        public bool Stop(HostControl hostControl)
        {
            if (_host == null)
                return true;
            _host.Stop();
            return true;
        }
        public void HostNancy(NancyHost _host)
        {
            try
            {
                var url = new Url(String.Format("http://localhost:{0}/xai/", "Port".ConfigValue("990")));
                var hc = new HostConfiguration
                {
                    UrlReservations = new UrlReservations { CreateAutomatically = true },
                    UnhandledExceptionCallback = o =>
                    {
                        LogModule.Error("框架层异常：" + o);
                    }
                };
                _host = new NancyHost(hc, url);
                Console.WriteLine("Listener address:" + url);
                _host.Start();
                //used for linux
                if (Type.GetType("Mono.Runtime") != null)
                {
                    UnixSignal.WaitAny(new[]
                    {
                        new UnixSignal(Signum.SIGINT),
                        new UnixSignal(Signum.SIGTERM),
                        new UnixSignal(Signum.SIGQUIT),
                        new UnixSignal(Signum.SIGHUP)
                    });
                }
                else
                {
                    //System.Diagnostics.Process.Start(url);
                }
            }
            catch (Exception ex)
            {
                LogModule.Error("RESTApiService->HostNancy:" + ex);
            }
        }
        public void Dispose()
        {
            GC.Collect();
        }

        #endregion
    }
}
