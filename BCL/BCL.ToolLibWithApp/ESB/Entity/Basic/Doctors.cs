using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Basic
{
    public class ExternalReqDoctors : ExternalReqBase
    {
        //文档无入参属性
    }

    public class DoctorAuthorizeDept
    {
        public int Id { get; set; }
        public string HospitalId { get; set; }
        public string DoctorCode { get; set; }
        public string DoctorName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
    }

    public class ExternalResDoctors : ExternalResBase
    {
        public List<DoctorInfo> DoctorList { get; set; }
        public ExternalResDoctors()
        {
            DoctorList = new List<DoctorInfo>();
        }
    }

    public class DoctorInfo
    {
        /// <summary>
        /// 医生代码
        /// </summary>
        public string DoctorCode { get; set; }

        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName { get; set; }

        public string BranchCode { get; set; }
        public string BranchName { get; set; }

        /// <summary>
        /// 医生介绍
        /// </summary>
        public string DoctorIntroduction { get; set; }

        /// <summary>
        /// 医生擅长
        /// </summary>
        public string DoctorGoodAt { get; set; }

        /// <summary>
        /// 医生职称
        /// </summary>
        public string DoctorTitle { get; set; }

        /// <summary>
        /// 登陆工号
        /// </summary>
        public string LoginNo { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        public string LoginPW { get; set; }
        public string Sex { get; set; }
        public string Birthday { get; set; }
        public string MobilePhoneNo { get; set; }
        public string AdminDeptCode { get; set; }
        public string AdminDeptName { get; set; }
        /// <summary>
        /// 快捷码
        /// </summary>
        public string QuickCode { get; set; }
    }
}
