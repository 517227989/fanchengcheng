using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.UPP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class UPPReqBase
    {
        public int? RowId { get; set; }
        public string Kind { get; set; }
        public string AppId { get; set; }
        public string OperCode { get; set; }
        public string TermCode { get; set; }
        public string ReqTime { get; set; }
        public string Channel { get; set; }
        public string Mode { get; set; }
        public string Class { get; set; }
        public string Args { get; set; }
        public string Random { get; set; }
        public string Sign { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class UPPResBase
    {
        public string ResCode { get; set; }
        public string ResMsg { get; set; }
        public string ResTime { get; set; }
        public string Args { get; set; }
        public string Random { get; set; }
        public string Sign { get; set; }
    }
    public class UPPBizResBase
    {
        public string ResCode { get; set; }
        public string ResMsg { get; set; }
    }
}
