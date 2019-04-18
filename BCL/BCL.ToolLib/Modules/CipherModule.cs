using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;

namespace BCL.ToolLib.Modules
{
    public interface ICipherModule
    {
        /// <summary>
        /// 创建密文
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        string BuildCipher(string s, string k);
        /// <summary>
        /// 创建明文
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        string BuildClear(string s, string k);
        /// <summary>
        /// 验证密文
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        bool VerifySign(string s, string k, string sign);
    }
    public class CipherModule_DES : ICipherModule
    {
        private static readonly byte[] _IV = { 0xEF, 0xAB, 0x56, 0x78, 0x90, 0x34, 0xCD, 0x12 };
        public string BuildCipher(string s, string k)
        {
            try
            {
                using (var _Ms = new MemoryStream())
                {
                    var _Sb = Encoding.UTF8.GetBytes(s);
                    using (var _Cs = new CryptoStream(_Ms, new DESCryptoServiceProvider().CreateEncryptor(Encoding.UTF8.GetBytes(k.Substring(0, 8)), _IV), CryptoStreamMode.Write))
                    {
                        _Cs.Write(_Sb, 0, _Sb.Length);
                        _Cs.FlushFinalBlock();
                        return Convert.ToBase64String(_Ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string BuildClear(string s, string k)
        {
            try
            {
                using (var _Ms = new MemoryStream(Convert.FromBase64String(s)))
                {
                    using (var _Cs = new CryptoStream(_Ms, new DESCryptoServiceProvider().CreateDecryptor(Encoding.UTF8.GetBytes(k.Substring(0, 8)), _IV), CryptoStreamMode.Read))
                    {
                        using (var _Sr = new StreamReader(_Cs))
                        {
                            return _Sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool VerifySign(string s, string k, string sign)
        {
            throw new NotImplementedException();
        }
    }
    public class CipherModule_AES : ICipherModule
    {
        private static readonly byte[] _IV = Encoding.UTF8.GetBytes("tR7nR6wZHGjYMCuV");
        public string BuildCipher(string s, string k)
        {
            try
            {
                using (var _Ms = new MemoryStream())
                {
                    var _Sb = Encoding.UTF8.GetBytes(s);
                    using (var _Cs = new CryptoStream(_Ms, new RijndaelManaged()
                    {
                        Padding = PaddingMode.PKCS7,
                        Mode = CipherMode.ECB,
                        KeySize = 128,
                        BlockSize = 128
                    }.CreateEncryptor(Encoding.UTF8.GetBytes(k.Substring(0, 16)), _IV), CryptoStreamMode.Write))
                    {
                        _Cs.Write(_Sb, 0, _Sb.Length);
                        _Cs.FlushFinalBlock();
                        return Convert.ToBase64String(_Ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string BuildClear(string s, string k)
        {
            try
            {
                using (var _Ms = new MemoryStream(Convert.FromBase64String(s)))
                {
                    using (var _Cs = new CryptoStream(_Ms, new RijndaelManaged()
                    {
                        Padding = PaddingMode.PKCS7,
                        Mode = CipherMode.ECB,
                        KeySize = 128,
                        BlockSize = 128
                    }.CreateDecryptor(Encoding.UTF8.GetBytes(k.Substring(0, 16)), _IV), CryptoStreamMode.Read))
                    {
                        using (var _Sr = new StreamReader(_Cs))
                        {
                            return _Sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool VerifySign(string s, string k, string sign)
        {
            throw new NotImplementedException();
        }
    }
    public class CipherModule_MD5 : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", "").ToLower();
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            throw new NotImplementedException();
        }
    }
    public class CipherModule_RSA : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            return Convert.ToBase64String(k.DecodeRSAKey(1024).Encrypt(Encoding.UTF8.GetBytes(s), false));
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            k = "-----BEGIN PUBLIC KEY-----\r\n" + k + "-----END PUBLIC KEY-----\r\n\r\n";
            using (var _RSA = new RSACryptoServiceProvider())
            {
                _RSA.PersistKeyInCsp = false;
                RSACryptoServiceProviderExtension.LoadPublicKeyPEM(_RSA, k);
                return _RSA.VerifyData(Encoding.UTF8.GetBytes(s), "SHA1", Convert.FromBase64String(sign));
            }
        }
    }
    public class CipherModule_RSA2 : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            return Convert.ToBase64String(k.DecodeRSAKey(2048).Encrypt(Encoding.UTF8.GetBytes(s), false));
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            k = "-----BEGIN PUBLIC KEY-----\r\n" + k + "-----END PUBLIC KEY-----\r\n\r\n";
            using (var _RSA = new RSACryptoServiceProvider())
            {
                _RSA.PersistKeyInCsp = false;
                RSACryptoServiceProviderExtension.LoadPublicKeyPEM(_RSA, k);
                return _RSA.VerifyData(Encoding.UTF8.GetBytes(s), "SHA256", Convert.FromBase64String(sign));
            }
        }
    }
    public class CipherModule_SHA1 : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            return BitConverter.ToString(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", "").ToLower();
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            throw new NotImplementedException();
        }
    }
    public class CipherModule_SHA256 : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            return BitConverter.ToString(new SHA256CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", "").ToLower();
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            throw new NotImplementedException();
        }
    }
    public class CipherModule_HMACMD5 : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            return BitConverter.ToString(new HMACMD5(Encoding.UTF8.GetBytes(k)).ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", "").ToLower();
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            throw new NotImplementedException();
        }
    }
    public class CipherModule_HMACSHA1 : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            return BitConverter.ToString(new HMACSHA1(Encoding.UTF8.GetBytes(k)).ComputeHash(Encoding.UTF8.GetBytes(s)));
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            throw new NotImplementedException();
        }
    }
    public class CipherModule_HMACSHA1_Base64 : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            return Convert.ToBase64String(new HMACSHA1(Encoding.UTF8.GetBytes(k)).ComputeHash(Encoding.UTF8.GetBytes(s)));
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            throw new NotImplementedException();
        }
    }
    public class CipherModule_HMACSHA256 : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            var xx = new HMACSHA256(Encoding.UTF8.GetBytes(k));
            return BitConverter.ToString(new HMACSHA256(Encoding.UTF8.GetBytes(k)).ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", "").ToLower();
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            throw new NotImplementedException();
        }
    }
    public class CipherModule_RSASHA1PKCS7 : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            var _Cms = new SignedCms(new ContentInfo(Encoding.UTF8.GetBytes(s)), true);
            _Cms.ComputeSignature(new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, new X509Certificate2(Directory.GetCurrentDirectory() + "\\" + k, k.Split('\\')[1]))
            {
                DigestAlgorithm = new Oid("SHA256"),
                IncludeOption = X509IncludeOption.EndCertOnly
            });
            return Convert.ToBase64String(_Cms.Encode());
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            throw new NotImplementedException();
        }
    }
    public class CipherModule_SHA256WithRSA2 : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            return Convert.ToBase64String(k.DecodeRSAKey(2048).SignData(Encoding.UTF8.GetBytes(s), "SHA256"));
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            throw new NotImplementedException();
        }
    }
    public class CipherModule_SHA256WithRSA : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            return Convert.ToBase64String(k.DecodeRSAKey(1024).SignData(Encoding.UTF8.GetBytes(s), "SHA1"));
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            throw new NotImplementedException();
        }
    }
    public class CipherModule_SHA256WithRSAPKCS12 : ICipherModule
    {
        public string BuildCipher(string s, string k)
        {
            Pkcs12Store store = new Pkcs12Store(new FileStream(k, FileMode.Open), k.Split('\\')[k.Split('\\').Count() - 2].ToCharArray());
            string pName = null;
            foreach (string n in store.Aliases)
            {
                if (store.IsKeyEntry(n))
                    pName = n;
            }
            byte[] data = Encoding.UTF8.GetBytes(s);
            IDigest digest = DigestUtilities.GetDigest("SHA256");
            digest.BlockUpdate(data, 0, data.Length);
            byte[] result = DigestUtilities.DoFinal(digest);
            var byteSignDigest = Encoding.UTF8.GetBytes(BitConverter.ToString(result).Replace("-", "").ToLower());
            ISigner normalSig = SignerUtilities.GetSigner("SHA256WithRSA");
            normalSig.Init(true, store.GetKey(pName).Key);
            normalSig.BlockUpdate(byteSignDigest, 0, byteSignDigest.Length);
            byte[] normalResult = normalSig.GenerateSignature();
            return Convert.ToBase64String(normalResult);
        }
        public string BuildClear(string s, string k)
        {
            throw new NotImplementedException();
        }
        public bool VerifySign(string s, string k, string sign)
        {
            byte[] data = Encoding.UTF8.GetBytes(s);
            IDigest digest = DigestUtilities.GetDigest("SHA256");
            digest.BlockUpdate(data, 0, data.Length);
            byte[] result = DigestUtilities.DoFinal(digest);
            var byteSignDigest = Encoding.UTF8.GetBytes(BitConverter.ToString(result).Replace("-", "").ToLower());
            k = k.Replace("-----END CERTIFICATE-----", "").Replace("-----BEGIN CERTIFICATE-----", "").Replace("\r\n", "");
            byte[] x509CertBytes = Convert.FromBase64String(k);
            Org.BouncyCastle.X509.X509Certificate x509Cert = new X509CertificateParser().ReadCertificate(x509CertBytes);
            ISigner verifier = SignerUtilities.GetSigner("SHA256WithRSA");
            verifier.Init(false, x509Cert.GetPublicKey());
            verifier.BlockUpdate(byteSignDigest, 0, byteSignDigest.Length);
            return verifier.VerifySignature(Convert.FromBase64String(sign));
        }
    }
}
