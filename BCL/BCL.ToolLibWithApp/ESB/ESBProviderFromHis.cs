using Autofac;
using BCL.ToolLib;
using BCL.ToolLib.Modules;
using System;
using System.Linq;
using System.ServiceModel;

namespace BCL.ToolLibWithApp.ESB
{
    #region Dev_ETrackInfo
    public class HisProviderOfETrackInfo : HisProvider
    {
        internal static WebServiceAgent _HISClient = null;
        public override string Business(params object[] args)
        {
            if (_HISClient == null)
                _HISClient = new WebServiceAgent("HisUrl".ConfigValue());
            return OnBusiness(o =>
            {
                var s = String.Empty;
                var x = _HISClient.Invoke("Etrack_ProcInterface", o[0].ToString(), s);
                if (x[1].ToString().IsNullOrEmptyOfVar())
                    throw new Exception("HIS错误:" + x[1].ToString());
                return x[1].ToString();
            }, args);
        }
    }
    #endregion

    #region Dev_MediInfo
    [ServiceContract]
    public partial interface IHisApplay
    {
        [OperationContract]
        int RunService(string TradeType, string TradeMsg, ref string TradeMsgOut);
    }
    public class HisProviderOfMediInfo : HisProvider
    {
        internal IHisApplay _HISClient { get; set; }
        public HisProviderOfMediInfo()
        {
            if (_HISClient == null)
                _HISClient = new RequestWsProvider<IHisApplay>("H" + _HOSPITALID).ReqClient;
        }
        public override string Business(params object[] args)
        {
            return OnBusiness(o =>
            {
                var s = String.Empty.PadRight(2048);
                var x = _HISClient.RunService(o[0].ToString(), o[1].ToString(), ref s);
                if (x < 0 || s.IsNullOrEmptyOfVar())
                    LogModule.Info("HIS错误:[" + x + "]" + s);
                return s;
            }, args);
        }
    }
    #endregion

    #region Basic
    public class HisProvider : IHisProvider
    {
        internal string _HOSPITALID => "HospitalId".ConfigValue();
        public virtual string Business(params object[] args)
        {
            throw new NotImplementedException();
        }
        public virtual string Push(params object[] args)
        {
            throw new NotImplementedException();
        }
        public virtual object[] OnEntry(params object[] args)
        {
            LogModule.Info("----------------------------------------------------------------");
            args.ToList().ForEach(o =>
            {
                LogModule.Info("入参:" + o);
            });
            return args;
        }
        public virtual string OnExit(string args)
        {
            LogModule.Info("出参:" + args);
            return args;
        }
        public virtual string OnBusiness(Func<object[], string> _Func, params object[] args)
        {
            try
            {
                return OnExit(_Func(OnEntry(args)));
            }
            catch (Exception ex)
            {
                LogModule.Info("异常:" + ex);
                throw ex;
            }
        }
    }
    public interface IHisProvider
    {
        string Business(params object[] args);
        string Push(params object[] args);
    }
    public class ESBProviderFromHis
    {
        public IHisProvider _Business { get; set; }
        public ESBProviderFromHis(string _HCode = null)
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterType(Type.GetType("BCL.ToolLibWithApp.ESB.ESBProvider.HisProviderH" + (_HCode ?? "HospitalId".ConfigValue()) + "Version".ConfigValue()))
                       .As<IHisProvider>();
                _Business = builder.Build()
                                   .Resolve<IHisProvider>();
            }
            catch (Exception ex)
            {
                LogModule.Info(ex);
                throw new Exception("创建HisProvider对象失败:" + ex.Message);
            }
        }
    }
    #endregion
}
