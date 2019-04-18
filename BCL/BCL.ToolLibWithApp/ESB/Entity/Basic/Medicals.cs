using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Basic
{
    /*
    * 基础数据诊疗
    */

    public class ExternalReqMedicals : ExternalReqBase
    {
        // //文档无入参属性
    }

    /*
    * 基础数据诊疗
     */

    public class ExternalResMedicals : ExternalResBase
    {
        public List<MedicalInfo> MedicalList { get; set; }
        public ExternalResMedicals()
        {
            MedicalList = new List<MedicalInfo>();
        }
    }

    public class MedicalInfo
    {
        /// <summary>
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }
        /// <summary>
        /// 诊疗代码
        /// </summary>
        public string MediCode { get; set; }

        /// <summary>
        /// 诊疗名称
        /// </summary>
        public string MediName { get; set; }

        /// <summary>
        /// 诊疗归类代码
        /// </summary>
        public string MediCalssifyCode { get; set; }

        /// <summary>
        /// 诊疗归类名称
        /// </summary>
        public string MediClassifyName { get; set; }

        /// <summary>
        /// 诊疗价格
        /// </summary>
        public string MediPrice { get; set; }

        /// <summary>
        /// 诊疗单位
        /// </summary>
        public string MediUnit { get; set; }
        /// <summary>
        /// 快捷码
        /// </summary>
        public string QuickCode { get; set; }

        /// <summary>
        /// 医保属性
        /// </summary>
        public MediProperty MediProperty { get; set; }

        /// <summary>
        /// 套餐明细
        /// </summary>
        public List<PackInfo> PackList { get; set; }
    }

    /*
    * 套餐明细
    */

    public class PackInfo
    {
        /// <summary>
        /// 诊疗代码
        /// </summary>
        public string MediCode { get; set; }

        /// <summary>
        /// 诊疗名称
        /// </summary>
        public string MediName { get; set; }

        /// <summary>
        /// 诊疗归类代码
        /// </summary>
        public string MediCalssifyCode { get; set; }

        /// <summary>
        /// 诊疗归类名称
        /// </summary>
        public string MediClassifyName { get; set; }

        /// <summary>
        /// 诊疗价格
        /// </summary>
        public string MediPrice { get; set; }

        /// <summary>
        /// 诊疗单位
        /// </summary>
        public string MediUnit { get; set; }

        /// <summary>
        /// 医保属性
        /// </summary>
        public MediProperty MediProperty { get; set; }

    }

    /*
       * 医保属性
       */

    public class MediProperty
    {
        /// <summary>
        /// 医保等级
        /// </summary>
        public string MediLevel { get; set; }

        /// <summary>
        /// 项目自付比例
        /// </summary>
        public string ItemPayRatio { get; set; }
    }
}
