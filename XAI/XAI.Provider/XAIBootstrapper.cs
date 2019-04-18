using BCL.ToolLib;
using BCL.ToolLib.Enums;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.UPP.Entity;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Session;
using Nancy.TinyIoc;
using System;
using System.Text;

namespace XAI.Provider
{
    public class XAIBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            CookieBasedSessions.Enable(pipelines);
            base.ApplicationStartup(container, pipelines);
        }
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.BeforeRequest += (x) =>
            {
                LogModule.Info("---------------------------------------I'm Split Line---------------------------------------");
                LogModule.Info("UPP->Req--->Url:" + x.Request.Url);
                return null;
            };

            pipelines.AfterRequest += (x) =>
            {
                if (x.Request.Url.Path.ToLower() == "/api" || x.Request.Url.Path.ToLower() == "/doc")
                    x.Response.WithContentType("application/pdf");
            };

            pipelines.OnError += Error;

            base.RequestStartup(container, pipelines, context);
        }
        private dynamic Error(NancyContext ctx, Exception ex)
        {
            var exMsg = new UPPResBase()
            {
                ResCode = ((int)ResCode.交易异常).ToString(),
                ResMsg = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message)
            }.ToJson();

            LogModule.Info("UPP->Err--->异常:" + exMsg);

            return new Response()
            {
                StatusCode = HttpStatusCode.OK,
                ContentType = "application/json;charset=UTF-8",
                Contents = (s) =>
                {
                    var exMsgEncode = Encoding.UTF8.GetBytes(exMsg);
                    s.Write(exMsgEncode, 0, exMsgEncode.Length);
                }
            };
        }
    }
}
