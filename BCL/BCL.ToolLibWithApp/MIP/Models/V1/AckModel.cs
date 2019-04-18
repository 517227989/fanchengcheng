using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BCL.ToolLibWithApp.MIP.Models.V1
{
    [XmlRoot("Root")]
    public class BngAckModel : BngBaseModel
    {
        public string Mode { get; set; }
        public string State { get; set; }
        public string ResNo { get; set; }
        public string AppCode { get; set; }
        public string ResDate { get; set; }
    }
    [XmlRoot("Root")]
    public class EndAckModel : BngAckModel
    {
        public EndAckModel()
        {
            MediFund = new MediFund();
            MediDetailList = new List<MediDetail>();
        }
        /// <summary>
        /// 医保交易流水号
        /// </summary>
        public string MediNo { get; set; }
        /// <summary>
        /// 医保交易日期
        /// </summary>
        public string MediDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HisId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DrugWindow { get; set; }
        /// <summary>
        /// 基金详情
        /// </summary>
        [XmlElement("Funds")]
        public MediFund MediFund { get; set; }
        /// <summary>
        /// 医保明细
        /// </summary>
        [XmlArray("Details"), XmlArrayItem("Detail")]
        public List<MediDetail> MediDetailList { get; set; }
    }
}
