using BCL.ToolLib;
using BCL.ToolLibWithApp.UPP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP
{
    public static class UPPToolBox
    {
        /// <summary>
        /// Ack of biz
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resCode"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string UPPAckOfBiz<T>(this Enum resCode, T entity)
        {
            var res = resCode.UPPAckOfRandom();
            res.Args = entity.ToJson();
            return res.ToJson();
        }
        /// <summary>
        /// Ack of json
        /// </summary>
        /// <param name="resCode"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string UPPAckOfJson(this Enum resCode, string key)
        {
            return resCode.UPPAckOfEntity(key).ToJson();
        }
        /// <summary>
        /// Ack of entity
        /// </summary>
        /// <param name="resCode"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static UPPResBase UPPAckOfEntity(this Enum resCode, string key)
        {
            var res = resCode.UPPAckOfRandom();
            //加签
            res.Sign = res.EntityToKeyValue(key).BuildCipher("", CipherKind.MD5);
            return res;
        }
        /// <summary>
        /// Ack of Random
        /// </summary>
        /// <param name="resCode"></param>
        /// <param name="addMsg"></param>
        /// <returns></returns>
        public static UPPResBase UPPAckOfRandom(this Enum resCode, string addMsg = "")
        {
            var res = resCode.UPPAckNoSign(addMsg);
            //加随机数
            res.Random = GuidKind.N.BuildRandom();
            return res;
        }
        /// <summary>
        /// Ack no sign
        /// </summary>
        /// <param name="resCode"></param>
        /// <returns></returns>
        public static UPPResBase UPPAckNoSign(this Enum resCode, string addMsg = "")
        {
            return new UPPResBase()
            {
                ResCode = Convert.ToInt32(resCode).ToString(),
                ResMsg = resCode.GetType().GetEnumName(Convert.ToInt32(resCode)) + (addMsg != "" ? ":" + addMsg : ""),
                ResTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
            };
        }
        /// <summary>
        /// entity convert to key=value and return sign
        /// </summary>
        /// <param name="req"></param>
        /// <param name="key"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static string EntityToKeyValueOfSign(this UPPReqBase req, string key, int mode)
        {
            req.Mode = mode.ToString();
            return req.EntityToKeyValue(key).BuildCipher("", CipherKind.MD5);
        }
    }
}
