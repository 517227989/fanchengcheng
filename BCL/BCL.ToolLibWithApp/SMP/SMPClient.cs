using BCL.ToolLib;
using BCL.ToolLib.Enums;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.SMP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.SMP
{

    public class SMPClient
    {
        public enum ParamKind
        {
            Send,
            Query
        }
        public SMPClient()
        {

        }
        public O OnExcuting<I, O>(I o, ParamKind _PKind = ParamKind.Send, MethodKind _Kind = MethodKind.GET) where I : SMSReqBase where O : SMSResBase
        {
            try
            {
                return ("SMPUrl".ConfigValue() + "/" + _PKind + "?" + o.EntityToKeyValue(false)).Get().ToEntity<O>();
            }
            catch (Exception ex)
            {
                LogModule.Info("SMP异常:" + ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
