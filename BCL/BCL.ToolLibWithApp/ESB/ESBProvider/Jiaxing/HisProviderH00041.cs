using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCL.ToolLib;
using System.ServiceModel;
using BCL.ToolLib.Modules;

namespace BCL.ToolLibWithApp.ESB.ESBProvider
{
    /// <summary>
    /// 嘉兴中医院
    /// </summary>
    
    public class HisProviderH00041 : HisProviderOfMediInfo
    {
        public override string Business(params object[] args)
        {
            return OnBusiness(o=> {
                //电子健康卡平台身份验证
                if (args.Contains("SFYZ"))
                {
                    var _Client = new RequestWsProvider<HealthCardService>("H" + _HOSPITALID + "_HCS").ReqClient;
                    var getAuthKey = args[0] as getAuthKey;
                    var res = _Client.getAuthKey(getAuthKey);
                    if (res != null)
                    {
                        if (res.@return != null)
                            return res.ToJson();
                    }
                    return null;
                }
                //电子健康卡平台建档
                else if (args.Contains("JD"))
                {
                    var _Client = new RequestWsProvider<HealthCardService>("H" + _HOSPITALID + "_HCS").ReqClient;
                    var syncCardInfo = args[0] as syncCardInfo;
                    var res = _Client.syncCardInfo(syncCardInfo);
                    if (res != null)
                    {
                        if (res.@return != null)
                            return res.ToJson();
                    }
                    return null;
                }
                else if (args.Contains("RWMCX")) //二维码查询
                {
                    var _Client = new RequestWsProvider<HealthCardService>("H" + _HOSPITALID + "_HCS").ReqClient;
                    var virIdCardVerify = args[0] as virIdCardVerify;
                    var res = _Client.virIdCardVerify(virIdCardVerify);
                    if (res != null)
                    {
                        if (res.@return != null)
                            return res.ToJson();
                    }
                    return null;
                }
                else
                {
                    //新地址的几个接口(人员信息查询:)
                    if (args[0].ToString().Contains("KL."))
                    {
                        LogModule.Info("入参接口信息:" + args[0].ToString());
                        var _Client = new RequestWsProvider<BCL.ToolLibWithApp.ESB.IHisApplay>("H" + _HOSPITALID + "_His2").ReqClient;
                        var s = String.Empty.PadRight(2048);
                        var x = _Client.RunService(o[0].ToString(), o[1].ToString(), ref s);
                        if (x < 0 || s.IsNullOrEmptyOfVar())
                            LogModule.Info("HIS错误:[" + x + "]" + s);
                        return s;
                    }
                    else
                    {
                        //var x = _HISClient.RunService(o[0].ToString(), o[1].ToString());
                        //return x;
                        //return base.Business(args);
                        var _Client = new RequestWsProvider<BCL.ToolLibWithApp.ESB.IHisApplay>("H" + _HOSPITALID).ReqClient;
                        var s = String.Empty.PadRight(2048);
                        var x = _Client.RunService(o[0].ToString(), o[1].ToString(), ref s);
                        if (x < 0 || s.IsNullOrEmptyOfVar())
                            LogModule.Info("HIS错误:[" + x + "]" + s);
                        return s;
                    }
                }
            },args);
            //return base.Business(args);
        }
    }
}
