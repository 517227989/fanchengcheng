using BCL.DataAccess;
using BCL.ToolLib;
using BCL.ToolLib.Enums;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.UPP.Entity;
using Dapper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BCL.ToolLibWithApp.UPP
{
    public class UPPClient
    {
        private static ConcurrentDictionary<string, UPPConfig> _UPPCONFIGCACHE = new ConcurrentDictionary<string, UPPConfig>();
        private UPPConfig _UPPCONFIG { get; set; }
        /// <summary>
        /// used by multi app of single hospital
        /// </summary>
        /// <param name="_AppId"></param>
        public UPPClient(string _AppId)
        {
            Init(_AppId);
        }
        /// <summary>
        /// used by single app of single hospital
        /// </summary>
        /// <param name="_HCode"></param>
        /// <param name="_BCode"></param>
        public UPPClient(string _HCode, string _BCode = "")
        {
            Init(_HCode + "#" + _BCode ?? "");
        }
        /// <summary>
        /// used by free config
        /// </summary>
        /// <param name="_UPPConfig"></param>
        public UPPClient(UPPConfig _UPPConfig)
        {
            _UPPCONFIG = _UPPConfig;
        }
        private void Init(string _Key)
        {
            _UPPCONFIG = _UPPCONFIGCACHE.Where(w => w.Key == _Key).FirstOrDefault().Value;
            if (_UPPCONFIG == null)
            {
                using (var dbContext = new DbContextContainer(DbName.UPPDb)._DataAccess)
                {
                    List<Db_App> dbAppList = null;
                    if (_Key.Contains("#"))
                    {
                        var _HCode = _Key.Split('#')[0];
                        var _HBCode = _Key.Split('#')[1] == _HCode ? "" : _Key.Split('#')[1];
                        var appId = "AppId".ConfigValue();
                        //AppId为空则为App根据HosCode查询
                        if (appId.IsNullOrEmptyOfVar())
                        {
                            _HBCode = _HCode == "00030" ? "" : _HBCode;
                            dbAppList = dbContext.Set<Db_App>().Where(w => w.HosCode == _HCode && w.Active == 0).AsNoTracking().ToList();
                        }
                        else
                            dbAppList = dbContext.Set<Db_App>().Where(w => w.HosCode == _HCode && w.Active == 0 && w.AppCode == appId).AsNoTracking().ToList();
                        if (!_HBCode.IsNullOrEmptyOfVar())
                            dbAppList = dbAppList.Where(w => w.BranchCode == _HBCode).ToList();
                    }
                    else
                    {
                        dbAppList = dbContext.Set<Db_App>().Where(w => w.AppCode == _Key && w.Active == 0).AsNoTracking().ToList();
                        if (dbAppList.Count == 0)
                            dbAppList = dbContext.Database.Connection.Query<Db_App>("SELECT A.* FROM UT_APP A,UT_APPLINK B WHERE A.APPCODE = B.APPCODE AND A.ACTIVE = 0 AND B.ACTIVE = 0 AND B.APPID = " + _Key).ToList();
                    }
                    if (dbAppList.Count == 0)
                        throw new Exception("UPPClient未找到相关配置");
                    if (dbAppList.FirstOrDefault().Url.IsNullOrEmptyOfVar())
                        throw new Exception("UPPClient未找到URL配置");
                    _UPPCONFIG = new UPPConfig()
                    {
                        AppId = dbAppList.FirstOrDefault().AppCode,
                        Key = dbAppList.FirstOrDefault().DevKey,
                        Url = dbAppList.FirstOrDefault().Url.ToLower().Contains("api") ? dbAppList.FirstOrDefault().Url : dbAppList.FirstOrDefault().Url + "api"
                    };
                    _UPPCONFIGCACHE.AddOrUpdate(_Key, _UPPCONFIG, (key, value) => value);
                }
            }
        }

        public virtual UPPBase OnExcuting(UPPBase _Req, UPPBiz _Biz, MethodKind _MKind = MethodKind.POST,int httpTimeOut=5)
        {
            _Req = OnExecutingBefore(_Req, _Biz);
            UPPBase res = null;
            var Url = "UPPUrl".ConfigValue();
            if (!Url.IsNullOrEmptyOfVar())
                _UPPCONFIG.Url = Url;
            if (_MKind == MethodKind.GET)
                res = (_UPPCONFIG.Url + "/" + _Req.Kind + "?" + _Req.EntityToKeyValue(false)).Get().ToEntity<UPPBase>();

            if (_MKind == MethodKind.POST)
                res = (_UPPCONFIG.Url + "/" + _Req.Kind).Post(_Req.EntityToKeyValue(false),timeout: httpTimeOut).ToEntity<UPPBase>();

            res = OnExecutingAfter(res);
            //补充添加APPCODE
            res.AppId = _Req.AppId;
            //返回
            return res;
        }
        protected virtual UPPBase OnExecutingBefore(UPPBase _Req, UPPBiz _Biz)
        {
            if (_UPPCONFIG == null)
                throw new ArgumentNullException("UPPClient配置错误，未获取到");
            //校验入参
            _Req.AppId = _Req.AppId.IsNullOrEmptyOfVar() ? _UPPCONFIG.AppId : _Req.AppId;
            _Req.AppId.IsNullOrEmptyOfVar("AppId");
            _Req.Kind.IsNullOrEmptyOfVar("Kind");
            _Req.Mode.IsNullOrEmptyOfVar("Mode");
            _Req.ReqTime = _Req.ReqTime.IsNullOrEmptyOfVar() ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : _Req.ReqTime;
            _Req.Random = _Req.Random.IsNullOrEmptyOfVar() ? GuidKind.N.BuildRandom() : _Req.Random;

            if (_Biz == null)
                throw new ArgumentNullException("UPPClient业务参数为null");

            //填充业务参数
            _Req.Args = _Biz.ToJson().UrlDecode();

            //加签
            _Req.Sign = _Req.EntityToKeyValue(_UPPCONFIG.Key).BuildCipher("", CipherKind.MD5);
            _Req.Args = _Biz.ToJson();
            LogModule.Info("UPPClient->UPP:入参:" + _Req.EntityToKeyValue(false));
            return _Req;
        }
        protected virtual UPPBase OnExecutingAfter(UPPBase _Res)
        {
            LogModule.Info("UPPClient->UPP:出参:" + _Res.EntityToKeyValue(false));
            //异常返回不再验签
            if (_Res.ResCode == "1001")
                throw new Exception(_Res.ResMsg);

            //验签
            if (_Res.Sign != _Res.EntityToKeyValue(_UPPCONFIG.Key).BuildCipher("", CipherKind.MD5))
                throw new Exception("UPPClient签名验证失败");

            return _Res;
        }
    }
    public class UPPConfig
    {
        public string AppId { get; set; }
        public string Url { get; set; }
        public string Key { get; set; }
    }
    public class UPPBase
    {
        public string Kind { get; set; }
        public string AppId { get; set; }
        public string Mode { get; set; }
        public string Class { get; set; }
        public string Args { get; set; }
        public string Sign { get; set; }
        public string Random { get; set; }
        public string ReqTime { get; set; }
        public string Channel { get; set; }
        public string ResCode { get; set; }
        public string ResMsg { get; set; }
        public string ResTime { get; set; }
        public string OperCode { get; set; }
        public string TermCode { get; set; }
    }
    public class UPPBiz
    {
        public string Index { get; set; }
        public string Mode { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string ReqNo { get; set; }
        public string ResNo { get; set; }
        public string Amount { get; set; }
        public string State { get; set; }
        public string UserNo { get; set; }
        public string PayType { get; set; }
        public string Reason { get; set; }
        public string SendDate { get; set; }
        public string AuthCode { get; set; }
        public string OrderInfo { get; set; }
        public string NotifyUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string TimeExpire { get; set; }
        public string EffectTime { get; set; }
        public string BackParams { get; set; }
        public string TradeType { get; set; }
        public string TotalAmount { get; set; }
        public string OpenId { get; set; }
        public string PhoneNo { get; set; }
        public string IsCanUpdateAmount { get; set; }
        public string OldReqNo { get; set; }
        public string PayAmount { get; set; }
        public string RefundTotalAmount { get; set; }
        public string RefundCount { get; set; }
        public List<RefundInfo> RefundList { get; set; }
        public string InitializeInfo { get; set; }
        public string BizType { get; set; }
        public string Code { get; set; }
        public string InData { get; set; }
        public string OutData { get; set; }
        public string FaceCode { get; set; }
    }
}
