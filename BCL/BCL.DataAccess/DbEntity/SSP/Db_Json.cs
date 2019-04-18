using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.SSP
{
    public class Db_Json
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称 
        /// </summary>
        public string JsonName { get; set; }
        /// <summary>
        /// Json数据
        /// </summary>
        public string JsonData { get; set; }
    }

    public class Db_JsonMapper : EntityTypeConfiguration<Db_Json>
    {
        public Db_JsonMapper()
        {
            ToTable("st_json");
            HasKey(w =>w.Id);
        }
    }
}
