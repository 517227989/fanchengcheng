using BCL.DataAccess;
using BCL.DataAccess.DbEntity.ESB;
using BCL.ToolLib;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.ESB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB
{
    public static class ESBToolBox
    {
        public static K InvokeWithESB<T, K>(this T o, string _TKind, string _HCode = null, string _BCode = null, string _TCode = null, string _OCode = null)
            where T : ExternalReqBase
            where K : ExternalResBase
        {
            return InvokeWithESB<T, K>(o, new BConfig()
            {
                TKind = _TKind,
                HCode = _HCode ?? "HospitalId".ConfigValue(),
                BCode = _BCode ?? "BranchCode".ConfigValue(),
                OCode = _OCode ?? "OperCode".ConfigValue(),
                TCode = _TCode ?? "TermCode".ConfigValue()
            });
        }
        public static K InvokeWithESB<T, K>(this T o, BConfig x)
            where T : ExternalReqBase
            where K : ExternalResBase
        {
            try
            {
                x.TKind.IsNullOrEmptyOfVar(x.TKind);
            }
            catch(ArgumentNullException ex)
            {
                throw ex;
            }
            return new ESBClient(x.HCode).OnExecu<T, K>(o, x);
        }
        public static string OnAck(this string _Code, string _Msgs, Exception ex = null)
        {
            if (ex != null)
                LogModule.Error(ex);
            return new ExternalResBase()
            {
                ResRet = new ResRet()
                {
                    ResRetCode = _Code,
                    ResRetMsg = _Msgs
                }
            }.ToJson();
        }

        public static string Ack(this string _Code, string _Msgs, Exception ex = null)
        {
            return _Code.OnAck(_Msgs, ex);
        }

        public static Db_Param GetParamByName(this string paramName, string hopitalId)
        {
            Db_Param dbParam = new Db_Param();
            try
            {
                if (!String.IsNullOrEmpty(paramName))
                {
                    using (var dbContext = new DbContextContainer(DbKind.MySql, DbName.HCDb)._DataAccess)
                    {
                        if (!String.IsNullOrEmpty(hopitalId))
                        {
                            dbParam = dbContext.Set<Db_Param>().AsNoTracking()
                                                               .Where(p => p.PARAM_NAME == paramName && p.HOSPITAL_ID == hopitalId).FirstOrDefault();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogModule.Error("ESBToolBox->GetParamByName():" + ex.Message);
            }
            return dbParam;
        }
    }
    public class AckException : ApplicationException
    {
        public AckException(string message) : base(message)
        {

        }
        public AckException(int code, string message) : base(message)
        {
            HResult = code;
        }
        public override string Message => base.Message;
    }
}
