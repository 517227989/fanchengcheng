using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Dept
    {
        public string HospitalId { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string DeptDescription { get; set; }
        public string DeptPosition { get; set; }
        public string BaseDept { get; set; }
        public string Type { get; set; }
        public int? OrderNum { get; set; }
        public string RegAgeLimit { get; set; }
        public string SexLimit { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public int? NeedAssess { get; set; }
        public int CheckMode { get; set; }
    }
    public class Db_DeptMapper : EntityTypeConfiguration<Db_Dept>
    {
        public Db_DeptMapper()
        {
            ToTable("AT_Depts");
            HasKey(k => new { k.HospitalId, k.DeptCode });
        }
    }
}
