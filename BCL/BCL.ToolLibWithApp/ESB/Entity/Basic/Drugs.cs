using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Basic
{
    /*
    * 基础数据药品
     */
    public class ExternalReqDrugs : ExternalReqBase
    {
        /// <summary>
        /// 药品类型
        /// </summary>
        public string DrugType { get; set; }
    }

    /*
        * 基础数据药品
     */

    public class ExternalResDrugs : ExternalResBase
    {
        public List<DrugInfo> DrugList { get; set; }
        public ExternalResDrugs()
        {
            DrugList = new List<DrugInfo>();
        }
    }

    public class DrugInfo
    {
        public DrugInfo()
        {
            MediProperty = new MediProperty();
        }
        /// <summary>
        /// 分院代码
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        /// 药品类型
        /// </summary>
        public string DrugType { get; set; }

        /// <summary>
        ///药品代码
        /// </summary>
        public string DrugCode { get; set; }

        /// <summary>
        ///药品名称
        /// </summary>
        public string DrugName { get; set; }

        /// <summary>
        ///药品产地代码
        /// </summary>
        public string DrugPlaceCode { get; set; }

        /// <summary>
        /// 药品产地名称
        /// </summary>
        public string DrugPlaceName { get; set; }

        /// <summary>
        /// 药品归类代码
        /// </summary>
        public string DrugClassifyCode { get; set; }

        /// <summary>
        /// 药品归类名称
        /// </summary>
        public string DrugClassifyName { get; set; }

        /// <summary>
        /// 药品价格
        /// </summary>
        public string DrugPrice { get; set; }

        /// <summary>
        /// 药品规格
        /// </summary>
        public string DrugSpecification { get; set; }
        /// <summary>
        /// 快捷码
        /// </summary>
        public string QuickCode { get; set; }

        /// <summary>
        /// 医保属性
        /// </summary>
        public MediProperty MediProperty { get; set; }

    }
}
