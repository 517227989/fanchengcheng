using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_DoctorAuthorizeDept
    {
        /// <summary>
        /// Id主键
        /// </summary>
        public int Id { get; set; }
        public string HospitalId { get; set; }
        public string DoctorCode { get; set; }
        public string DoctorName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public int OrderNum { get; set; }
    }
    public class Db_DoctorAuthorizeDeptMapper : EntityTypeConfiguration<Db_DoctorAuthorizeDept>
    {
        public Db_DoctorAuthorizeDeptMapper()
        {
            ToTable("AT_DoctorAuthorizeDept");
            HasKey(k => k.Id);
        }
    }
}
