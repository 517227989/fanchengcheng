using BCL.ToolLibWithApp.XAI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAI.Business
{
    /// <summary>
    /// 基础接口
    /// </summary>
    public interface IBusiness
    {
        /// <summary>
        /// 人脸认证
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        XAIResAuth Auth(XAIReqAuth reqData);
        /// <summary>
        /// 人脸识别
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        XAIResFind Find(XAIReqFind reqData);
        /// <summary>
        /// 人脸新增
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        XAIResFAdd FAdd(XAIReqFAdd reqData);
        /// <summary>
        /// 人脸更新
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        XAIResFMod FMod(XAIReqFMod reqData);
        /// <summary>
        /// 人脸删除
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        XAIResFDel FDel(XAIReqFDel reqData);
        /// <summary>
        /// 用户查询
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        XAIResFGet FGet(XAIReqFGet reqData);
        /// <summary>
        /// 新增用户组
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        XAIResAddGroup AddGroup(XAIReqAddGroup reqData);
        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        XAIResDeleteGroup DeleteGroup(XAIReqDeleteGroup reqData); 
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        XAIResGetUserList GetUserList(XAIReqGetUserList reqData);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        XAIResDeleteFace DeleteFace(XAIReqDeleteFace reqData);
    }
}
