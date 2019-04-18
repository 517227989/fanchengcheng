using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Information
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 文件
        /// </summary>
        public string File { get; set; }
        /// <summary>
        /// 0正常1作废
        /// </summary>
        public int IsCancel { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime? AddDate { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        public string AddUser { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModDate { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModUser { get; set; }
    }
    public class Db_InformationMapper : EntityTypeConfiguration<Db_Information>
    {
        public Db_InformationMapper()
        {
            ToTable("Mr_Information");
            HasKey(k => new { k.Id });
        }
    }
}
