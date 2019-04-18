using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess
{
    /// <summary>
    /// 字典信息表
    /// </summary>
    public class Db_Dictionarys : Db_Base
    {
        public string DictCode { get; set; }
        public string DictName { get; set; }
        public string CodeRule { get; set; }
        public string ClassId { get; set; }
        public int State { get; set; }
        public string QuickCode { get; set; }
        public string DictId { get; set; }
    }
    public class Db_DictionarysMapper : EntityTypeConfiguration<Db_Dictionarys>
    {
        public Db_DictionarysMapper()
        {
            ToTable("upm_dictionary");
            HasKey(o => o.Id);
            Ignore(o => o.ModDate);
            Ignore(o => o.OperCode);
            Ignore(o => o.Remarks);
            Ignore(o => o.AddDate);
        }
    }
}
