using BCL.DataAccess;
using BCL.DataAccess.DbEntity.ESB;
using BCL.ToolLib;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.ESB.Entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB
{
    [ServiceContract]
    public interface IExternalInterface
    {
        [OperationContract]
        int ReqBusiness(string HospitalId, string CompanyCode, string TradeType, string TradeMsg, ref string TradeMsgOut);
    }
    [ServiceContract]
    public interface IBusinessInterface
    {
        [OperationContract]
        int ReqBusiness(string HospitalId, string CompanyCode, string TradeType, string TradeMsg, ref string TradeMsgOut);
    }
    public class BConfig
    {
        public string HCode { get; set; }
        public string TKind { get; set; }
        public string TCode { get; set; }
        public string OCode { get; set; }
        public string BCode { get; set; }
        public string BName { get; set; }
    }
    public class ESBClient
    {
        private static IExternalInterface _ESBClient { get; set; }
        public ESBClient(String _HCode)
        {
            _ESBClient = new RequestWsProvider<IExternalInterface>(_HCode).ReqClient;
        }
        public virtual T OnEntry<T>(T o, BConfig x) where T : class
        {
            LogModule.Info("执行ESB请求开始:------------------------------------------------------------------------------------------");
            LogModule.Info("执行ESB请求交易:" + x.TKind);
            LogModule.Info("执行ESB请求入参:" + o.ToJson());
            return o;
        }
        public virtual T OnExits<T>(T o, BConfig x) where T : class
        {
            LogModule.Info("执行ESB请求出参:" + o);
            return o;
        }
        public virtual K OnExecu<T, K>(T o, BConfig x)
            where T : ExternalReqBase
            where K : ExternalResBase
        {
            try
            {
                using (var dbContext = new DbContextContainer(DbName.HCDb)._DataAccess)
                {
                    var dynamicSql = @"SELECT * 
                                         FROM AT_RegDev
                                        WHERE AuthorizeHospitalCode = '" + x.HCode + "' " +
                                         "AND RegDevCode = 'Conlin'";
                    var dbRegDev = dbContext.Database.Connection.QueryFirstOrDefault<Db_RegDev>(dynamicSql);
                    o.ReqHeader = new ReqHeader(dbRegDev, x.BCode, x.TCode, x.OCode);
                    var s = String.Empty;
                    var v = _ESBClient.ReqBusiness(o.ReqHeader.ReqHospitalCode, o.ReqHeader.ReqCompanyCode, x.TKind, OnEntry(o, x).ToJson(), ref s);
                    return OnExits(s, x).ToEntity<K>();
                }
            }
            catch (Exception ex)
            {
                LogModule.Info("执行ESB请求异常:", ex);
                throw ex;
            }
        }

        public virtual string OnExecuting(string hospitalId, string companyCode, string tradeType, string tradeMsg)
        {
            try
            {
                var tradeMsgOut = String.Empty;
                LogModule.Info(string.Format("T->A:{0}:{1}", tradeType, tradeMsg));
                var retMsg = _ESBClient.ReqBusiness(hospitalId, companyCode, tradeType, tradeMsg, ref tradeMsgOut);
                LogModule.Info(string.Format("A->T:{0}:{1}", tradeType, retMsg + tradeMsgOut));
                return tradeMsgOut;
            }
            catch (Exception ex)
            {
                LogModule.Info(ex);
                throw new Exception(string.Format("ESB异常:{0}->{1}", tradeType, ex.Message));
            }
        }
    }

    public class CESBClient
    {
        private static IBusinessInterface _CESBClient { get; set; }
        public CESBClient(String _CCode = "00000")
        {
            _CESBClient = new RequestWsProvider<IBusinessInterface>(_CCode).ReqClient;
        }
        public virtual string OnExecuting(string hospitalId, string companyCode, string tradeType, string tradeMsg)
        {
            try
            {
                var tradeMsgOut = String.Empty;
                LogModule.Info(string.Format("T->A:{0}:{1}", tradeType, tradeMsg));
                var retMsg = _CESBClient.ReqBusiness(hospitalId, companyCode, tradeType, tradeMsg, ref tradeMsgOut);
                LogModule.Info(string.Format("A->T:{0}:{1}", tradeType, tradeMsgOut));
                return tradeMsgOut;
            }
            catch (Exception ex)
            {
                LogModule.Info(ex);
                throw new Exception(string.Format("CESB异常:{0}->{1}", tradeType, ex.Message));
            }
        }
    }
}
