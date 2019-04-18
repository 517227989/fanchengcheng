using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_Doctor
    {
        public string HospitalId { get; set; }
        public string DoctorCode { get; set; }
        public string DoctorName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string DoctorIntroduction { get; set; }
        public string Direction { get; set; }
        public string DoctorGoodAt { get; set; }
        public string DoctorTitle { get; set; }
        public string LoginNo { get; set; }
        public string LoginPW { get; set; }
        public string MorPerson { get; set; }
        public string BackPic { get; set; }
        public string Sex { get; set; }
        public string Logo { get; set; }
        public string NoonPerson { get; set; }
        public string AdminDeptCode { get; set; }
        public string AdminDeptName { get; set; }
        public int? OrderNum { get; set; }
        public string QuickCode { get; set; }
    }
    public class Db_DoctorMapper : EntityTypeConfiguration<Db_Doctor>
    {
        public Db_DoctorMapper()
        {
            ToTable("AT_Doctors");
            HasKey(k => new { k.HospitalId, k.DoctorCode });
        }
    }
}
