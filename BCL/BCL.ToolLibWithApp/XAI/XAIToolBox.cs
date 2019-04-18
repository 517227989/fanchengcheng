using BCL.ToolLib;
using BCL.ToolLibWithApp.XAI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.XAI
{
    public static class XAIToolBox
    {
        /// <summary>
        /// Ack of biz
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resCode"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string XAIAckOfBiz<T>(this Enum resCode, T entity)
        {
            var res = entity.ToJson().ToEntity<XAIResBase>();
            res.Code = Convert.ToInt32(resCode).ToString();
            res.Desc = resCode.GetType().GetEnumName(Convert.ToInt32(resCode));
            return res.ToJson();
        }
        /// <summary>
        /// Ack of biz
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resCode"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string XAIAckOfBiz<T>(this Enum resCode, string entity)
        {
            return new XAIResBase
            {
                Code = Convert.ToInt32(resCode).ToString(),
                Desc = resCode.GetType().GetEnumName(Convert.ToInt32(resCode))
            }.ToJson();
        }
    }
}
