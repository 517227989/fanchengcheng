using Autofac;
using BCL.ToolLib;
using BCL.ToolLibWithApp.XAI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAI.Business
{
    public class BusinessContainer
    {
        /// <summary>
        /// 业务对象
        /// </summary>
        public IBusiness _Business { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="busKind"></param>
        /// <param name="req"></param>
        public BusinessContainer(string busKind, XAIReqBase req)
        {
            DoInit(busKind, req);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="busKind"></param>
        /// <param name="req"></param>
        private void DoInit(string busKind, XAIReqBase req)
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterType(Type.GetType("XAI.Business.Business" + "BIDU"))
                       .WithParameter("_Req", req)
                       .As<IBusiness>();
                _Business = builder.Build()
                                   .Resolve<IBusiness>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException());
            }
        }
    }
}
