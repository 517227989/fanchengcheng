using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Dictionary_items
    {
        public int Id { get; set; }
        public string Dict_Id { get; set; }
        public string Item_Id { get; set; }
        public string Item_Name { get; set; }
        public string Parent_Id { get; set; }
        public string Item_Level { get; set; }
        public int? System_Flag { get; set; }
        public int? Final_Flag { get; set; }
        public int? Order_No { get; set; }
        public string Modified_By { get; set; }
        public string Modified_Date { get; set; }
        public DateTime? Delete_Date { get; set; }
        public string Remark { get; set; }
        public string Item_Code { get; set; }
        public string Char1 { get; set; }
        public string Char2 { get; set; }
        public string Char3 { get; set; }
        public string Char4 { get; set; }
        public string Char5 { get; set; }
        public string Char6 { get; set; }
        public int? Num1 { get; set; }
        public int? Num2 { get; set; }
        public int? Num3 { get; set; }
        public int? Num4 { get; set; }
        public int? Num5 { get; set; }
        public int? Num6 { get; set; }
        public string Datetime1 { get; set; }
        public string Datetime2 { get; set; }
        public string Datetime3 { get; set; }
        public int? Delete_Flag { get; set; }
        public string Quick_Code1 { get; set; }
        public string Quick_Code2 { get; set; }
        public string Quick_Code3 { get; set; }
    }
    public class Db_Dictionary_itemsMapper : EntityTypeConfiguration<Db_Dictionary_items>
    {
        public Db_Dictionary_itemsMapper()
        {
            ToTable("ct_dictionary_item");
            HasKey(o => o.Id);
        }
    }
}
