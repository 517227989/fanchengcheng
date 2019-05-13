using BCL.ToolLib.Modules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace BCL.ToolLib
{
    public enum CipherKind
    {
        DES,
        AES,
        RSA,
        MD5,
        RSA2,
        SHA1,
        SHA256,
        HMACMD5,
        HMACSHA1,
        HMACSHA1_Base64,
        HMACSHA256,
        RSASHA1PKCS7,
        SHA256WithRSA,
        SHA256WithRSA2,
        SHA256WithRSAPKCS12
    }
    public enum GuidKind
    {
        /// <summary>
        /// ece4f4a60b764339b94a07c84e338a27
        /// </summary>
        N,
        /// <summary>
        /// 5bf99df1-dc49-4023-a34a-7bd80a42d6bb
        /// </summary>
        D,
        /// <summary>
        /// {2280f8d7-fd18-4c72-a9ab-405de3fcfbc9}
        /// </summary>
        B,
        /// <summary>
        /// //(25e6e09f-fb66-4cab-b4cd-bfb429566549)
        /// </summary>
        P,
    }
    public static partial class ToolsContainer
    {
        /// <summary>
        /// object[]打包带分隔字符串
        /// </summary>
        /// <param name="o"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToJoin(this object[] o, string s, string p = "")
        {
            return p + string.Join(s, o) + p;
        }
        /// <summary>
        /// Linq Or连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> x, Expression<Func<T, bool>> o)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Or(x.Body, Expression.Invoke(o, x.Parameters.Cast<Expression>())), x.Parameters);
        }
        /// <summary>
        /// Linq AND连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> x, Expression<Func<T, bool>> o)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.And(x.Body, Expression.Invoke(o, x.Parameters.Cast<Expression>())), x.Parameters);
        }
        /// <summary>
        /// on receive message from message queue
        /// </summary>
        /// <param name="qName"></param>
        /// <param name="_Func"></param>
        /// <param name="qKind"></param>
        public static void OnRecvMQ(this string qName, Func<string, bool> _Func, MQKind qKind = MQKind.RBMQ)
        {
            new MQModuleContainer(qKind)._MQModule.RecvMessage(qName, _Func);
        }
        /// <summary>
        /// on send message to message queue
        /// </summary>
        /// <param name="qMsgs"></param>
        /// <param name="qName"></param>
        /// <param name="qKind"></param>
        public static void OnSendMQ(this string qMsgs, string qName, MQKind qKind = MQKind.RBMQ)
        {
            new MQModuleContainer(qKind)._MQModule.SendMessage(qName, qMsgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string EntityToKeyValueOfEncode(this object entity)
        {
            var s = "";
            entity.GetType().GetProperties().OrderBy(x => x.Name, StringComparer.Ordinal).ToList().ForEach(o =>
            {
                var v = o.GetValue(entity);
                //the null is except
                if (v != null && !String.IsNullOrEmpty(v.ToString()))
                    s += o.Name.UrlEncodeToUpper() + "=" + v.ToString().UrlEncodeToUpper() + "&";
            });
            return s.Remove(s.Length - 1, 1);
        }
        /// <summary>
        /// used for AL
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="except"></param>
        /// <returns></returns>
        public static Dictionary<string, string> EntityToKeyValueOfAL(this object entity, string except)
        {
            var s = new Dictionary<string, string>();
            entity.GetType().GetProperties().ToList().ForEach(o =>
            {
                //except sign value
                if (except.Contains("#" + o.Name + "#") == false)
                {
                    var v = o.GetValue(entity);
                    //the null is except
                    if (v != null)
                        s.Add(o.Name.ToLower(), v.ToString());
                }
            });
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UrlEncodeToUpper(this string s)
        {
            var x = new StringBuilder();
            Encoding.UTF8.GetBytes(s).ToList().ForEach(o =>
            {
                if ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~".IndexOf(Convert.ToChar(o)) >= 0)
                    x.Append(Convert.ToChar(o));
                else
                    x.Append("%").Append(string.Format(CultureInfo.InvariantCulture, "{0:X2}", (int)o));
            });
            return x.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UrlEncode(this string s)
        {
            return HttpUtility.UrlEncode(s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UrlDecode(this string s)
        {
            return HttpUtility.UrlDecode(s);
        }
        /// <summary>
        /// is guid
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string IsGuid(this string s)
        {
            try
            {
                return new Guid(s).ToString();
            }
            catch
            {
                throw new ArgumentException(s);
            }
        }
        /// <summary>
        /// convert to dictionary and sort as ASCII
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDicSort<T>(this T o) where T : class
        {
            var d = new Dictionary<string, string>();
            o.GetType().GetProperties().OrderBy(x => x.Name, StringComparer.Ordinal).ToList().ForEach(x =>
            {
                var v = x.GetValue(o);
                if (v != null)
                    d.Add(x.Name, v.ToString());
            });
            return d;
        }
        /// <summary>
        /// RSA Build Sign
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k">PrivateKey</param>
        /// <param name="_CK"></param>
        /// <returns></returns>
        public static string BuildSign(this string s, string k, CipherKind _CK = CipherKind.RSA2)
        {
            if (_CK == CipherKind.RSA)
                return Convert.ToBase64String(k.DecodeRSAKey(1024).SignData(Encoding.UTF8.GetBytes(s), "SHA1"));
            else
                return Convert.ToBase64String(k.DecodeRSAKey(2048).SignData(Encoding.UTF8.GetBytes(s), "SHA256"));
        }
        /// <summary>
        /// decode RSA key
        /// </summary>
        /// <param name="k"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static RSACryptoServiceProvider DecodeRSAKey(this string k, int s)
        {
            byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;
            using (var _MS = new MemoryStream(Convert.FromBase64String(k)))
            {
                using (var _BR = new BinaryReader(_MS))
                {
                    var _TB = _BR.ReadUInt16();
                    if (_TB == 0x8130)
                        _BR.ReadByte();
                    else if (_TB == 0x8230)
                        _BR.ReadInt16();
                    else
                        return null;

                    _TB = _BR.ReadUInt16();
                    if (_TB != 0x0102)
                        return null;
                    if (_BR.ReadByte() != 0x00)
                        return null;

                    MODULUS = _BR.ReadBytes(_BR.GetIntegerSize());
                    E = _BR.ReadBytes(_BR.GetIntegerSize());
                    D = _BR.ReadBytes(_BR.GetIntegerSize());
                    P = _BR.ReadBytes(_BR.GetIntegerSize());
                    Q = _BR.ReadBytes(_BR.GetIntegerSize());
                    DP = _BR.ReadBytes(_BR.GetIntegerSize());
                    DQ = _BR.ReadBytes(_BR.GetIntegerSize());
                    IQ = _BR.ReadBytes(_BR.GetIntegerSize());

                    CspParameters CspParameters = new CspParameters
                    {
                        Flags = CspProviderFlags.UseMachineKeyStore
                    };

                    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(s, CspParameters);
                    RSAParameters RSAparams = new RSAParameters
                    {
                        Modulus = MODULUS,
                        Exponent = E,
                        D = D,
                        P = P,
                        Q = Q,
                        DP = DP,
                        DQ = DQ,
                        InverseQ = IQ
                    };
                    RSA.ImportParameters(RSAparams);
                    return RSA;
                }
            }
        }
        /// <summary>
        /// get int size
        /// </summary>
        /// <param name="binr"></param>
        /// <returns></returns>
        public static int GetIntegerSize(this BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)     //expect integer
                return 0;
            bt = binr.ReadByte();

            if (bt == 0x81)
                count = binr.ReadByte();    // data size in next byte
            else
                if (bt == 0x82)
            {
                highbyte = binr.ReadByte(); // data size in next 2 bytes
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;     // we already have the data size
            }

            while (binr.ReadByte() == 0x00)
            {   //remove high order zeros in data
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);       //last ReadByte wasn't a removed zero, so back up a byte
            return count;
        }
        /// <summary>
        /// CNY fen to yuan
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string CNY_F2Y(this string s)
        {
            return (Convert.ToDecimal(s) / 100).ToString("F2");
        }
        /// <summary>
        /// CNY yuan to fen
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string CNY_Y2F(this string s)
        {
            return (Convert.ToDecimal(s) * 100).ToString("#");
        }
        /// <summary>
        /// is Phone NO
        /// </summary>
        /// <param name="s"></param>
        public static void IsPhoneNo(this string s)
        {
            if (new Regex(@"^(1[\d]{10},)*(1[\d]{10})$").IsMatch(s) == false)
                throw new ArgumentException("非手机号码");
        }
        /// <summary>
        /// is datetime format
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static void IsDateTime(this string s, string v = null)
        {
            try
            {
                Convert.ToDateTime(s);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(v + "非日期格式" + ex.Message);
            }
        }
        /// <summary>
        /// convert to datetime string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToDateTime(this string s)
        {
            if (String.IsNullOrEmpty(s))
                return null;
            return DateTime.ParseExact(s, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// is number
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static void IsNumber(this string s)
        {
            if (new Regex(@"^(-?\d+)(\.\d+)?$").IsMatch(s) == false)
                throw new ArgumentException("非数字格式");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNumberOfVar(this string s)
        {
            return new Regex(@"^(-?\d+)(\.\d+)?$").IsMatch(s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string s)
        {
            return Convert.ToDecimal(s);
        }
        /// <summary>
        /// convert to int
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int ToInt(this object o)
        {
            return Convert.ToInt32(o);
        }
        /// <summary>
        /// enum name to val
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int EnumNameToValue<T>(this string s)
        {
            return (int)Enum.Parse(typeof(T), s);
        }
        /// <summary>
        /// random
        /// </summary>
        /// <returns></returns>
        public static string BuildRandom(this GuidKind _GK)
        {
            return Guid.NewGuid().ToString(_GK.ToString()).ToLower();
        }
        /// <summary>
        /// entity convert to key=value
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string EntityToKeyValue(this object entity, string key)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException("key is null");

            return EntityToKeyValue(entity) + "&key=" + key;
        }
        /// <summary>
        /// entity convert to key1=value1&key2=value2
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string EntityToKeyValue(this object entity, bool sign = true)
        {
            var s = "";
            entity.GetType().GetProperties().OrderBy(x => x.Name, StringComparer.Ordinal).ToList().ForEach(o =>
             {
                 //except sign value
                 if ((sign == true && o.Name.ToUpper() == "SIGN"))
                 { }
                 else
                 {
                     var v = o.GetValue(entity, null);
                     //the null is except
                     if (v != null && !String.IsNullOrEmpty(v.ToString()))
                         s += o.Name + "=" + v + "&";
                 }
             });
            return s.Remove(s.Length - 1, 1);
        }
        /// <summary>
        /// entity convert to key1=value1&key2=value2
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string EntityToKeyValue(this Dictionary<string, string> entity, string Key)
        {
            var s = "";
            entity.OrderBy(x => x.Key, StringComparer.Ordinal).ToList().ForEach(o =>
            {
                //except sign value
                if (o.Key.ToUpper() == "SIGN")
                { }
                else
                {
                    var v = o.Value;
                    //the null is except
                    if (v != null && !String.IsNullOrEmpty(v.ToString()))
                        s += o.Key + "=" + v + "&";
                }
            });
            return s.Remove(s.Length - 1, 1) + Key;
        }
        /// <summary>
        /// entity convert to key1=value1&key2=value2
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string EntityToKeyValue(this Dictionary<string, object> entity, string Key)
        {
            var s = "";
            entity.OrderBy(x => x.Key, StringComparer.Ordinal).ToList().ForEach(o =>
            {
                //except sign value
                if (o.Key.ToUpper() == "SIGN")
                { }
                else
                {
                    var v = o.Value;
                    //the null is except
                    if (v != null && !String.IsNullOrEmpty(v.ToString()))
                        if (v.GetType() == typeof(Dictionary<string, object>))
                            s += o.Key + "=" + v.ToJson() + "&";
                        else
                            s += o.Key + "=" + v + "&";
                }
            });
            return s.Remove(s.Length - 1, 1) + Key;
        }
        /// <summary>
        /// key1=value1&key2=value2 convert to Dictionary
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Dictionary<string, string> KeyValueToDictionary(this string KetValue)
        {
            KetValue = HttpUtility.UrlDecode(KetValue);

            var dic = new Dictionary<String, String>();
            KetValue.Split('&').ToList().ForEach(o =>
            {
                dic.Add(o.Split('=')[0], o.Split('=')[1]);
            });
            return dic;
        }
        /// <summary>
        /// build cipher text
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <param name="_CK"></param>
        /// <returns></returns>
        public static string BuildCipher(this string s, string k, CipherKind _CK = CipherKind.DES)
        {
            var _ICM = Activator.CreateInstance(Type.GetType("BCL.ToolLib.Modules.CipherModule_" + _CK.ToString())) as ICipherModule;
            return _ICM.BuildCipher(s, k);
        }
        /// <summary>
        /// build clear text
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <param name="_CK"></param>
        /// <returns></returns>
        public static string BuildClear(this string s, string k, CipherKind _CK = CipherKind.DES)
        {
            var _ICM = Activator.CreateInstance(Type.GetType("BCL.ToolLib.Modules.CipherModule_" + _CK.ToString())) as ICipherModule;
            return _ICM.BuildClear(s, k);
        }
        /// <summary>
        /// build clear text
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <param name="_CK"></param>
        /// <returns></returns>
        public static bool VerifySign(this string s, string k, string sign, CipherKind _CK = CipherKind.RSA2)
        {
            var _ICM = Activator.CreateInstance(Type.GetType("BCL.ToolLib.Modules.CipherModule_" + _CK.ToString())) as ICipherModule;
            return _ICM.VerifySign(s, k, sign);
        }
        /// <summary>
        /// convert to xml
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string ToXml(this object obj)
        {
            using (var s = new MemoryStream())
            {
                var xns = new XmlSerializerNamespaces();
                xns.Add("", "");
                new XmlSerializer(obj.GetType()).Serialize(s, obj, xns);
                s.Position = 0;
                using (var sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        /// <summary>
        /// convert to entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T X2Entity<T>(this string obj) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(obj))
                {
                    XmlSerializer xmldes = new XmlSerializer(typeof(T));
                    return xmldes.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("无效的XML串:" + ex.Message);
            }
        }
        /// <summary>
        /// convert to json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj, int _NVH = 1)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings() { NullValueHandling = (NullValueHandling)_NVH, DateFormatString = "yyyy-MM-dd HH:mm:ss" });
        }
        /// <summary>
        /// convert to entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ToEntity<T>(this string obj) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("无效的JSON串:" + ex.Message);
            }
        }
        /// <summary>
        /// 判断IsNullOrEmpty，并抛出异常
        /// </summary>
        /// <param name="s"></param>
        /// <param name="v">导致异常的参数的名称</param>
        public static void IsNullOrEmptyOfVar(this string s, string v)
        {
            if (String.IsNullOrEmpty(s))
                throw new ArgumentNullException(v);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOfVar(this string s)
        {
            return String.IsNullOrEmpty(s);
        }

        /// <summary>
        /// 判断IsNullOrEmpty，并设置默认值
        /// </summary>
        /// <param name="s"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static string IsNullOrEmptySetVar(this string s, string v)
        {
            if (String.IsNullOrEmpty(s))
                return v;
            else
                return s;
        }

        /// <summary>
        /// get config
        /// </summary>
        /// <param name="varName">参数名称</param>
        /// <returns></returns>
        public static string ConfigValue(this string varName)
        {
            string outVar = "";
            try
            {
                outVar = System.Configuration.ConfigurationManager.AppSettings[varName];
                return outVar ?? "";
            }
            catch
            {
                return outVar;
            }
        }
        /// <summary>
        /// get config
        /// </summary>
        /// <param name="varName">参数名称</param>
        /// <param name="initValue">初始值</param>
        /// <returns></returns>
        public static string ConfigValue(this string varName, string initValue)
        {
            string outVar = "";
            try
            {
                outVar = System.Configuration.ConfigurationManager.AppSettings[varName];
                if (string.IsNullOrEmpty(outVar))
                    outVar = initValue;
                return outVar;
            }
            catch
            {
                return initValue;
            }
        }

        /// <summary>
        /// key=value&key=value to entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="req"></param>
        /// <returns></returns>
        public static T Bind<T>(this string req) where T : class, new()
        {
            var entity = new T();
            if (req.IsNullOrEmptyOfVar())
                return entity;
            var kv = new Dictionary<String, String>();
            req.Split('&').ToList().ForEach(o =>
            {
                if (o.Contains('='))
                    kv.Add(o.Split('=')[0].ToUpper(), o.Substring(o.IndexOf('=') + 1));
            });
            entity.GetType().GetProperties().ToList().ForEach(o =>
            {
                o.SetValue(entity, kv.Where(w => w.Key == o.Name.ToUpper()).Count() > 0 ? kv[o.Name.ToUpper()] : null);
            });
            return entity;
        }
        /// <summary>
        /// cert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        /// <summary>
        /// request Post
        /// </summary>
        /// <param name="val"></param>
        /// <param name="url"></param>
        /// <param name="isUseCert"></param>
        /// <returns></returns>
        public static string Post(this string url, string val, bool isUseCert = false, string contentType = "application/x-www-form-urlencoded;charset=UTF-8;", string sslPath = null, int timeout = 5, string encode = "UTF-8", string securityProtocolType = null)
        {
            GC.Collect();
            string result = "";
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            try
            {
                ServicePointManager.DefaultConnectionLimit = 200;
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                if (!securityProtocolType.IsNullOrEmptyOfVar())
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)securityProtocolType.EnumNameToValue<SecurityProtocolType>();
                req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.Timeout = timeout * 1000;
                req.ReadWriteTimeout = 5 * 1000;
                req.ContentType = contentType;
                req.ServicePoint.Expect100Continue = false;
                req.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                if (isUseCert)
                {
                    X509Certificate2 cert = new X509Certificate2(Directory.GetCurrentDirectory() + "\\" + sslPath, sslPath.Split('\\')[1]);
                    req.ClientCertificates.Add(cert);
                }
                var v = Encoding.GetEncoding(encode).GetBytes(val);
                req.ContentLength = v.Length;

                var s = req.GetRequestStream();
                s.Write(v, 0, v.Length);
                s.Close();
                res = (HttpWebResponse)req.GetResponse();
                using (var sr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding(encode)))
                {
                    result = sr.ReadToEnd().Trim();
                }
            }
            catch (ThreadAbortException ex)
            {
                LogModule.Error(ex);
                Thread.ResetAbort();
                throw new Exception(ex.Message);
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                    LogModule.Error(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                LogModule.Error(ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                //关闭连接和流
                if (res != null)
                    res.Close();
                if (req != null)
                    req.Abort();
            }
            return result;
        }
        /// <summary>
        /// request Get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Get(this string url, int timeout = 100)
        {
            GC.Collect();
            string result = "";
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            try
            {
                ServicePointManager.DefaultConnectionLimit = 200;
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
                req.Timeout = timeout * 1000;
                res = (HttpWebResponse)req.GetResponse();
                using (var sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
                {
                    result = sr.ReadToEnd().Trim();
                }
            }
            catch (ThreadAbortException ex)
            {
                LogModule.Error(ex);
                Thread.ResetAbort();
                throw new Exception(ex.Message);
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                    LogModule.Error(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                LogModule.Error(ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (res != null)
                    res.Close();
                if (req != null)
                    req.Abort();
            }
            return result;
        }
        /// <summary>
        /// Json To HttpResponseMessage
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static HttpResponseMessage JsonToHRM(this Object obj)
        {
            String str;
            if (obj is String || obj is Char)
            {
                str = obj.ToString();
            }
            else
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                str = serializer.Serialize(obj);
            }
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }
        /// <summary>
        /// app Signature verification
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <param name="nonce"></param>
        /// <param name="token"></param>
        /// <param name="data"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public static bool Validate(string timeStamp, string nonce, string token, string data, string signature)
        {
            var hash = MD5.Create();
            //拼接签名数据
            var signStr = data + token + timeStamp + nonce;
            return signStr.BuildCipher("", CipherKind.MD5).ToLower() == signature;
        }
        //自增主键
        private static int rd_Int = 0; //一个递增的数字
        /// <summary>
        /// 创建Id
        /// </summary>
        /// <param name="PrdfixStr"></param>
        /// <returns></returns>
        public static String CreateKey(this string PrdfixStr)
        {
            rd_Int += 1;
            if (rd_Int > 99)
            {
                rd_Int = 0;
            }
            String rd_String = String.Format("{0:D3}", rd_Int);
            var r = String.Format("{0:D2}", new Random(Guid.NewGuid().GetHashCode()).Next(10, 99));
            String key = PrdfixStr + DateTime.Now.ToString("yyyyMMddHHmmssfff") + rd_String + r;
            return key;
        }
        /// <summary>
        /// 判断文件类型是否是图片
        /// </summary>
        /// <param name="ImageUrl"></param>
        /// <returns></returns>
        public static bool CheckTestFile(this string ImageUrl)
        {
            String reg = ".+(.JPEG|.jpeg|.JPG|.jpg|.GIF|.gif|.PNG|.png|.BMP|.bmp)$";
            bool bl = Regex.IsMatch(ImageUrl, reg);
            return bl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static string ConvertToABC(string c)
        {
            byte[] array = new byte[2];
            array = Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "j";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";
            return "*";
        }
        /// <summary>
        /// 转换中文字母
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToABC(this string s)
        {
            if (s.IsNullOrEmptyOfVar())
                return null;
            string ret = string.Empty;
            foreach (char c in s)
            {
                if (c.ToString().Trim().IsNullOrEmptyOfVar())
                    continue;
                if (c >= 33 && c <= 126)
                    ret += c.ToString().ToUpper();
                else
                    ret += ConvertToABC(c.ToString()).ToUpper();
            }
            return ret;
        }

        /// <summary>
        /// 获取内部错误信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string InnerException(this Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;
            else
                return ex.InnerException.InnerException();
        }

        /// <summary>  
        /// 验证身份证合理性  
        /// </summary>  
        /// <param name="Id"></param>  
        /// <returns></returns>  
        public static bool CheckIDCard(string idNumber)
        {
            if (idNumber.Length == 18)
            {
                if (long.TryParse(idNumber.Remove(17), out long n) == false
                || n < Math.Pow(10, 16) || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
                    return false;//数字验证
                string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
                if (address.IndexOf(idNumber.Remove(2)) == -1)
                    return false;//省份验证  
                string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");
                DateTime time = new DateTime();
                if (DateTime.TryParse(birth, out time) == false)
                    return false;//生日验证  
                string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
                string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
                char[] Ai = idNumber.Remove(17).ToCharArray();
                int sum = 0;
                for (int i = 0; i < 17; i++)
                    sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
                int y = -1;
                Math.DivRem(sum, 11, out y);
                if (arrVarifyCode[y] != idNumber.Substring(17, 1).ToLower())
                    return false;//校验码验证  
                return true;//符合GB11643-1999标准  
            }
            else if (idNumber.Length == 15)
            {
                if (long.TryParse(idNumber, out long n) == false || n < Math.Pow(10, 14))
                    return false;//数字验证  
                string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
                if (address.IndexOf(idNumber.Remove(2)) == -1)
                    return false;//省份验证  
                string birth = idNumber.Substring(6, 6).Insert(4, "-").Insert(2, "-");
                DateTime time = new DateTime();
                if (DateTime.TryParse(birth, out time) == false)
                    return false;//生日验证  
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 读取HIS返回的XML,用于测试
        /// </summary>
        /// <returns></returns>
        public static string ReadXmlStr(string url)
        {
            try
            {
                string str = System.IO.File.ReadAllText(url);
                return str;
            }
            catch (Exception ex)
            {
                return "读取xml信息失败:" + ex.Message;
            }
        }
        /// <summary>
        /// 根据身份证获取年龄
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public static int GetAgeByCardNo(string cardNo)
        {
            string birth = "";
            if (cardNo.Length == 18)
            {
                birth = cardNo.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            }
            if (cardNo.Length == 15)
            {
                birth = cardNo.Substring(6, 6).Insert(4, "-").Insert(2, "-");
                birth = "19" + birth;
            }
            var dtBirth = Convert.ToDateTime(birth);
            if (DateTime.Now.DayOfYear >= dtBirth.DayOfYear)
            {
                return DateTime.Now.Year - dtBirth.Year;
            }
            else
            {
                if (DateTime.Now.Year == dtBirth.Year)
                    return 0;
                return DateTime.Now.Year - dtBirth.Year - 1;
            }
        }
        /// <summary>
        /// 根据出生日期获取年龄
        /// </summary>
        /// <param name="birth"></param>
        /// <returns></returns>
        public static int GetAgeByBirth(string birth)
        {

            var dtBirth = Convert.ToDateTime(birth);
            if (DateTime.Now.DayOfYear >= dtBirth.DayOfYear)
            {
                return DateTime.Now.Year - dtBirth.Year;
            }
            else
            {
                if (DateTime.Now.Year == dtBirth.Year)
                    return 0;
                return DateTime.Now.Year - dtBirth.Year - 1;
            }
        }
        private static char[] base64CodeArray = new char[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4',  '5', '6', '7', '8', '9', '+', '/', '='
        };
        public static bool IsBase64(this string base64Str)
        {
            //string strRegex = "^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{4}|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)$";
            if (string.IsNullOrEmpty(base64Str))
                return false;
            else
            {
                if (base64Str.Contains(","))
                    base64Str = base64Str.Split(',')[1];
                if (base64Str.Length % 4 != 0)
                    return false;
                if (base64Str.Any(c => !base64CodeArray.Contains(c)))
                    return false;
            }
            try
            {
                var bytes = Convert.FromBase64String(base64Str);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


    }
    #region 动态生产有规律的ID
    /// <summary>
    /// 动态生产有规律的ID
    /// </summary>
    public class Snowflake
    {
        private static long machineId;//机器ID
        private static long datacenterId = 0L;//数据ID
        private static long sequence = 0L;//计数从零开始

        private static readonly long twepoch = 687888001020L; //唯一时间随机量

        private static readonly long machineIdBits = 5L; //机器码字节数
        private static readonly long datacenterIdBits = 5L;//数据字节数
        public static long maxMachineId = -1L ^ -1L << (int)machineIdBits; //最大机器ID
        private static readonly long maxDatacenterId = -1L ^ (-1L << (int)datacenterIdBits);//最大数据ID

        private static readonly long sequenceBits = 12L; //计数器字节数，12个字节用来保存计数码        
        private static readonly long machineIdShift = sequenceBits; //机器码数据左移位数，就是后面计数器占用的位数
        private static long datacenterIdShift = sequenceBits + machineIdBits;
        private static readonly long timestampLeftShift = sequenceBits + machineIdBits + datacenterIdBits; //时间戳左移动位数就是机器码+计数器总字节数+数据字节数
        public static long sequenceMask = -1L ^ -1L << (int)sequenceBits; //一微秒内可以产生计数，如果达到该值则等到下一微妙在进行生成
        private static long lastTimestamp = -1L;//最后时间戳

        private static object syncRoot = new object();//加锁对象
        static Snowflake snowflake;

        public static Snowflake Instance()
        {
            if (snowflake == null)
                snowflake = new Snowflake();
            return snowflake;
        }

        public Snowflake()
        {
            Snowflakes(0L, -1);
        }

        public Snowflake(long machineId)
        {
            Snowflakes(machineId, -1);
        }

        public Snowflake(long machineId, long datacenterId)
        {
            Snowflakes(machineId, datacenterId);
        }

        private void Snowflakes(long machineId, long datacenterId)
        {
            if (machineId >= 0)
            {
                if (machineId > maxMachineId)
                {
                    throw new Exception("机器码ID非法");
                }
                Snowflake.machineId = machineId;
            }
            if (datacenterId >= 0)
            {
                if (datacenterId > maxDatacenterId)
                {
                    throw new Exception("数据中心ID非法");
                }
                Snowflake.datacenterId = datacenterId;
            }
        }

        /// <summary>
        /// 生成当前时间戳
        /// </summary>
        /// <returns>毫秒</returns>
        private static long GetTimestamp()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        /// <summary>
        /// 获取下一微秒时间戳
        /// </summary>
        /// <param name="lastTimestamp"></param>
        /// <returns></returns>
        private static long GetNextTimestamp(long lastTimestamp)
        {
            long timestamp = GetTimestamp();
            if (timestamp <= lastTimestamp)
            {
                timestamp = GetTimestamp();
            }
            return timestamp;
        }

        /// <summary>
        /// 获取长整形的ID
        /// </summary>
        /// <returns></returns>
        public long GetId()
        {
            lock (syncRoot)
            {
                long timestamp = GetTimestamp();
                if (lastTimestamp == timestamp)
                { //同一微妙中生成ID
                    sequence = (sequence + 1) & sequenceMask; //用&运算计算该微秒内产生的计数是否已经到达上限
                    if (sequence == 0)
                    {
                        //一微妙内产生的ID计数已达上限，等待下一微妙
                        timestamp = GetNextTimestamp(lastTimestamp);
                    }
                }
                else
                {
                    //不同微秒生成ID
                    sequence = 0L;
                }
                if (timestamp < lastTimestamp)
                {
                    throw new Exception("时间戳比上一次生成ID时时间戳还小，故异常");
                }
                lastTimestamp = timestamp; //把当前时间戳保存为最后生成ID的时间戳
                long Id = ((timestamp - twepoch) << (int)timestampLeftShift)
                    | (datacenterId << (int)datacenterIdShift)
                    | (machineId << (int)machineIdShift)
                    | sequence;
                return Id;
            }
        }
    }
    #endregion
}
