using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Basic
{
    public class ExternalReqDepts : ExternalReqBase
    {
        //文档无入参属性
    }
    public class ExternalResDepts : ExternalResBase
    {
        public List<DeptInfo> DeptList { get; set; }
        public ExternalResDepts()
        {
            DeptList = new List<DeptInfo>();
        }
    }

    /// <summary>
    /// 科室信息
    /// </summary>
    public class DeptInfo
    {
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DeptCode { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 科室描述
        /// </summary>
        public string DeptDescription { get; set; }

        /// <summary>
        /// 父类科室
        /// </summary>
        public string BaseDept { get; set; }
        public string BaseDeptName { get; set; }
        public string DeptPosition { get; set; }
        public string RegAgeLimit { get; set; }
        public string SexLimit { get; set; }
        public int? OrderNum { get; set; }
        public string Type { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
    }
}
