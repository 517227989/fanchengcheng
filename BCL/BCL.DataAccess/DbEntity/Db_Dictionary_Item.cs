using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
/*
 * Create By:Hui
 * Create Date:2017-08-22
 * Des:
 * 公用码-详细
 */
namespace BCL.DataAccess
{
    public class Db_Dictionary_Item 
    {
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DictId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ItemLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FinalFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OrderNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Des { get; set; }
    }

    public class Db_Dictionary_ItemMapper : EntityTypeConfiguration<Db_Dictionary_Item>
    {
        public Db_Dictionary_ItemMapper()
        {
            ToTable("upm_dictionary_item");
            HasKey(o => o.Id);
        }
    }
}
