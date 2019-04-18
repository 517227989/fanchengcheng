using BCL.DataAccess;
using BCL.ToolLib;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.SMP;
using BCL.ToolLibWithApp.SMP.Entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP
{
    public class UPPNotice
    {
        /// <summary>
        /// 
        /// </summary>
        protected static ConcurrentDictionary<string, Db_App> _AppCache = new ConcurrentDictionary<string, Db_App>();
        /// <summary>
        /// 
        /// </summary>
        public UPPNotice()
        {
            if (_AppCache == null || _AppCache.Count == 0)
                _AppCache.DbAppConfig();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbDetails"></param>
        /// <param name="dbOrder"></param>
        public void UPPNotify(Db_AppDetail dbDetails, Db_AppOrder dbOrder)
        {
            if (string.IsNullOrEmpty(dbOrder.NotifyUrl))
                return;
            var v = Convert.ToInt32("NorCount".ConfigValue("3"));
            var _App = _AppCache.Where(w => w.Key == dbDetails.AppCode).FirstOrDefault().Value;
            LogModule.Info("UPP->Nor--->开始通知:创建线程==================================");
            var x = Task.Run(() =>
            {
                var i = 1;
                do
                {
                    try
                    {
                        var notify = new UPPNoticeEntity()
                        {
                            Random = GuidKind.N.BuildRandom(),
                            Amount = dbDetails.Amount.ToString(),
                            AppId = dbDetails.AppCode,
                            HosCode = dbDetails.HosCode,
                            Kind = dbDetails.Kind,
                            PsDate = dbDetails.PsDate.ToString("yyyy-MM-dd HH:mm:ss"),
                            PsNo = dbDetails.PsNo,
                            ReqDate = dbDetails.ReqDate.ToString("yyyy-MM-dd HH:mm:ss"),
                            ReqNo = dbDetails.ReqNo,
                            ResDate = dbDetails.ResDate.ToString("yyyy-MM-dd HH:mm:ss"),
                            ResNo = dbDetails.ResNo,
                            State = dbDetails.State.ToString(),
                            Mode = dbDetails.Mode,
                            Index = dbDetails.Index,
                            Name = dbDetails.Name,
                            BackParams = dbOrder.BackParams,
                            NotifyTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        };
                        notify.Sign = notify.EntityToKeyValue(_App.DevKey).BuildCipher("", CipherKind.MD5);
                        var req = notify.EntityToKeyValue(false);
                        LogModule.Info("UPP->Nor--->参数：" + req);
                        var res = string.Empty;
                        if (dbOrder.ReqChannel == "17" && dbOrder.TermCode == "ConlinApp")
                        {
                            res = dbOrder.NotifyUrl.Post(notify.ToJson(), false, "application/json");
                        }
                        else
                            res = dbOrder.NotifyUrl.Post(req);
                        LogModule.Info("UPP->Nor--->结果：" + res);
                        if (res == "OK")
                            i = 5;//终止推送通知
                    }
                    catch (Exception ex)
                    {
                        LogModule.Info("UPP->Nor--->异常：" + ex.Message);
                    };
                    i++;
                    if (i <= v)
                        Thread.Sleep(10000);
                }
                while (i <= v);
            });
            LogModule.Info("UPP->Nor--->通知发送:运行线程Id:" + x.Id + "================================");
        }
        /// <summary>
        /// 短信发送
        /// </summary>
        /// <param name="dbOrder"></param>
        /// <param name="content"></param>
        public void UPPMessage(Db_AppOrder dbOrder, string content)
        {
            if (dbOrder.PhoneNo.IsNullOrEmptyOfVar())
                return;
            var v = Convert.ToInt32("MsgCount".ConfigValue("3"));
            LogModule.Info("UPP->Msg--->开始发送短信:创建线程==================================");
            var x = Task.Run(() =>
            {
                var i = 1;
                do
                {
                    try
                    {
                        var reqSend = new SMSReqSend
                        {
                            SMSKind = "SMSKind".ConfigValue(),
                            PhoneNo = dbOrder.PhoneNo,
                            Content = content,
                            TempCode = "UPP",
                            SendDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            SignName = "SMSSign".ConfigValue(),
                        };
                        LogModule.Info("SMP--->参数：" + reqSend.ToJson());
                        var resSend = new SMPClient().OnExcuting<SMSReqSend, SMSResSend>(reqSend);
                        LogModule.Info("SMP--->结果：" + resSend.ToJson());
                        i = 5;//终止发送短信
                    }
                    catch (Exception ex)
                    {
                        LogModule.Info("SMP--->异常：" + ex.Message);
                    };
                    i++;
                    if (i <= v)
                        Thread.Sleep(10000);
                }
                while (i <= v);
            });
            LogModule.Info("UPP->Msg--->发送短信完毕:运行线程Id:" + x.Id + "================================");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbDetails"></param>
        /// <param name="dbOrder"></param>
        public void UPPAgreeNotify(Db_Agreement dbAgreement)
        {
            if (dbAgreement == null || dbAgreement.NotifyUrl.IsNullOrEmptyOfVar())
                return;
            var v = Convert.ToInt32("NorCount".ConfigValue("3"));
            var _App = _AppCache.Where(w => w.Key == dbAgreement.AppCode).FirstOrDefault().Value;
            LogModule.Info("UPP->Nor--->开始通知:创建线程==================================");
            var x = Task.Run(() =>
            {
                var i = 1;
                do
                {
                    try
                    {
                        var notify = new UPPAgreeNoticeEntity()
                        {
                            NotifyTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            Random = GuidKind.N.BuildRandom(),
                            Kind = dbAgreement.Status == 2 ? "AgreeSign" : "AgreeUnsign",
                            AppId = dbAgreement.AppCode,
                            Mode = dbAgreement.Mode,
                            Index = dbAgreement.Index,
                            Name = dbAgreement.Name,
                            AgreeNo = dbAgreement.AgreeNo.ToString(),
                            Uid = dbAgreement.Uid,
                            LoginId = dbAgreement.LoginId,
                            ValidTime = dbAgreement.ValidTime.HasValue ? dbAgreement.ValidTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : null,
                            InvalidTime = dbAgreement.InvalidTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                            Status = dbAgreement.Status.ToString(),
                            PCode = dbAgreement.PCode,
                        };
                        notify.Sign = notify.EntityToKeyValue(_App.DevKey).BuildCipher("", CipherKind.MD5);
                        var req = notify.EntityToKeyValue(false);
                        LogModule.Info("UPP->Nor--->参数：" + req);
                        var res = dbAgreement.NotifyUrl.Post(notify.ToJson(), false, "application/json");
                        LogModule.Info("UPP->Nor--->结果：" + res);
                        if (res == "OK")
                            i = 5;//终止推送通知
                    }
                    catch (Exception ex)
                    {
                        LogModule.Info("UPP->Nor--->异常：" + ex.Message);
                    };
                    i++;
                    if (i <= v)
                        Thread.Sleep(10000);
                }
                while (i <= v);
            });
            LogModule.Info("UPP->Nor--->通知发送:运行线程Id:" + x.Id + "================================");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class UPPNoticeEntity
    {
        public string NotifyTime { get; set; }
        public string Random { get; set; }
        public string Sign { get; set; }
        public string Kind { get; set; }
        public string AppId { get; set; }
        public string HosCode { get; set; }
        public string ReqNo { get; set; }
        public string ReqDate { get; set; }
        public string PsNo { get; set; }
        public string PsDate { get; set; }
        public string ResNo { get; set; }
        public string ResDate { get; set; }
        public string Amount { get; set; }
        public string State { get; set; }
        public string Mode { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public string BackParams { get; set; }
    }
    public class UPPAgreeNoticeEntity
    {
        public string NotifyTime { get; set; }
        public string Random { get; set; }
        public string Sign { get; set; }
        public string Kind { get; set; }
        public string AppId { get; set; }
        public string Mode { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public string AgreeNo { get; set; }
        public string Uid { get; set; }
        public string LoginId { get; set; }
        public string ValidTime { get; set; }
        public string InvalidTime { get; set; }
        public string Status { get; set; }
        public string PCode { get; set; }
    }
}
