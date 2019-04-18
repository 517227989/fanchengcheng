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

                    return ResCode.交易成功.XAIAckOfBiz(new XAIResAddGroup()).ToJson();
                }
                catch (Exception ex)
                {
                    LogModule.Info(ex);
                    return ResCode.业务错误.XAIAckOfBiz(ex.Message).ToJson();
                }
            };
        }
    }
}
