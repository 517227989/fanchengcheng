using BCL.ToolLib;
using BCL.ToolLib.Enums;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.XAI;
using BCL.ToolLibWithApp.XAI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAI.Provider.Modules
{
    public class XAIAdminModule : XAIModule
    {
        public XAIAdminModule() : base("/Admin")
        {
            Init();

            Before += RequestFilter;

            After += ResponseFilter;

            Post["/AddGroup"] = o =>
            {
                try
                {
                    var biz = _Req.Args.ToEntity<XAIReqAddGroup>();
                    #region 参数判断
                    biz.GroupId.IsNullOrEmptyOfVar("GroupId");
                    #endregion

                    var resAddGroup = _Business.AddGroup(biz);

                    return ResCode.交易成功.XAIAckOfBiz(new XAIResAddGroup());
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfErr(ex.Message);
                }
            };

            Post["/DeleteGroup"] = o =>
            {
                try
                {
                    var biz = _Req.Args.ToEntity<XAIReqDeleteGroup>();
                    #region 参数判断
                    biz.GroupId.IsNullOrEmptyOfVar("GroupId");
                    #endregion

                    var resAddGroup = _Business.DeleteGroup(biz);

                    return ResCode.交易成功.XAIAckOfBiz(new XAIResDeleteGroup());
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfErr(ex.Message);
                }
            };
        }
    }
}
