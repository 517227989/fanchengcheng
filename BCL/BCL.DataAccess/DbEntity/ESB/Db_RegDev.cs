using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_RegDev
    {
        public int Id { get; set; }
        public string RegDevCode { get; set; }
        public string RegDevName { get; set; }
        public string RegApproveCode { get; set; }
        public string AuthorizeHospitalCode { get; set; }
        public string AuthorizeHospitalName { get; set; }
        public DateTime RegDate { get; set; }
        public string RegOper { get; set; }
        public int Active { get; set; }
        public int DevState { get; set; }
        public int Ciphertext { get; set; }
    }
    public class Db_RegDevMapper : EntityTypeConfiguration<Db_RegDev>
    {
        public Db_RegDevMapper()
        {
            ToTable("AT_RegDev");
            HasKey(o => o.Id);
        }
    }
}
