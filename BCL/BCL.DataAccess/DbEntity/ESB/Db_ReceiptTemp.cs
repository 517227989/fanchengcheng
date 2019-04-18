using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_ReceiptTemp
    {
        public int Id { get; set; }
        public string HospitalId { get; set; }
        public int LineNum { get; set; }
        public string TempCode { get; set; }
        public string TempName { get; set; }
        public string VarCode { get; set; }
        public string VarName { get; set; }
        public string VarValue { get; set; }
        public string StyleMark { get; set; }
        /// <summary>
        /// 20181031 yinqi  咨询过陈文锋 答复没问题后添加
        /// </summary>
        public int TempType { get; set; }
    }
    public class Db_ReceiptTempMapper : EntityTypeConfiguration<Db_ReceiptTemp>
    {
        public Db_ReceiptTempMapper()
        {
            ToTable("AT_ReceiptTemp");
            HasKey(k => k.Id);
        }
    }
}
