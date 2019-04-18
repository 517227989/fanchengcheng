using BCL.DataAccess.DbEntity.ESB;
using System;

namespace BCL.ToolLibWithApp.ESB.Entity
{
    public class ExternalReqBase
    {
        /// <summary>
        /// 属性名称必须与json字符中保存一致,切记！
        /// </summary>
        public ReqHeader ReqHeader { get; set; }
        public ExternalReqBase()
        {
            ReqHeader = new ReqHeader();
        }
    }
    /// <summary>
    /// 请求头
    /// </summary>
    public class ReqHeader
    {
        /// <summary>
        /// 请求厂商代码
        /// </summary>
        public string ReqCompanyCode { get; set; }
        /// <summary>
        /// 请求厂商名称
        /// </summary>
        public string ReqCompanyName { get; set; }
        /// <summary>
        /// 请求认证码
        /// </summary>
        public string ReqApproveCode { get; set; }
        /// <summary>
        /// 请求医院代码
        /// </summary>
        public string ReqHospitalCode { get; set; }
        /// <summary>
        /// 请求医院名称
        /// </summary>
        public string ReqHospitalName { get; set; }
        /// <summary>
        /// 请求分院代码
        /// </summary>
        public string ReqBranchCode { get; set; }
        /// <summary>
        /// 请求分院名称
        /// </summary>
        public string ReqBranchName { get; set; }
        /// <summary>
        /// 请求终端代码
        /// </summary>
        public string ReqTermCode { get; set; }
        /// <summary>
        /// 请求日期
        /// </summary>
        public string ReqDate { get; set; }
        /// <summary>
        /// 请求操作工号
        /// </summary>
        public string ReqOper { get; set; }
        /// <summary>
        /// 请求交易流水号
        /// </summary>
        public string GUID { get; set; }
        public ReqHeader()
        {
            //ReqCompanyCode = ReqCompanyCode;
            //ReqCompanyName = ReqCompanyName;
            //ReqApproveCode = ReqApproveCode;
            //ReqHospitalCode = ReqHospitalCode;
            //ReqHospitalName = ReqHospitalName;
            //ReqBranchCode = ReqBranchCode ?? "";
            //ReqBranchName = "";
            //ReqTermCode = ReqTermCode ?? "";
            //ReqDate = DateTime.Now.ToString();
            //ReqOper = ReqOper ?? "CONLINAPP";
            //GUID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="regDev"></param>
        public ReqHeader(Db_RegDev regDev, string _BranchCode = null, string _TermCode = null, string _OperCode = null)
        {
            ReqCompanyCode = regDev.RegDevCode;
            ReqCompanyName = regDev.RegDevName;
            ReqApproveCode = regDev.RegApproveCode;
            ReqHospitalCode = regDev.AuthorizeHospitalCode;
            ReqHospitalName = regDev.AuthorizeHospitalName;
            ReqBranchCode = _BranchCode ?? "";
            ReqBranchName = "";
            ReqTermCode = _TermCode ?? "";
            ReqDate = DateTime.Now.ToString();
            ReqOper = _OperCode ?? "CONLINAPP";
            GUID = Guid.NewGuid().ToString();
        }
    }

    public class ExternalResBase
    {
        /// <summary>
        /// 属性名称必须与json字符中保存一致,切记！
        /// </summary>
        public ResRet ResRet { get; set; }
        public ExternalResBase()
        {
            ResRet = new ResRet();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ResRet
    {
        /// <summary>
        /// 响应返回码
        /// </summary>
        public string ResRetCode { get; set; }

        /// <summary>
        /// 响应返回消息
        /// </summary>
        public string ResRetMsg { get; set; }
    }
}
