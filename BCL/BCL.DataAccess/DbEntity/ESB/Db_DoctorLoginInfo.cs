using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_DoctorLoginInfo
    {
        public int Id { get; set; }
        public String HospitalId { get; set; }
        public String RoomId { get; set; }
        public String RoomName { get; set; }
        public DateTime? LoginDate { get; set; }
        public DateTime? LogoutDate { get; set; }
        public String LoginState { get; set; }
        public String TypeCode { get; set; }
        public String TypeName { get; set; }
        public String DeptCode { get; set; }
        public String DeptName { get; set; }
        public String DoctorCode { get; set; }
        public String DoctorName { get; set; }
        public String DoctorState { get; set; }
    }
    public class Db_DoctorLoginInfoMapper : EntityTypeConfiguration<Db_DoctorLoginInfo>
    {
        public Db_DoctorLoginInfoMapper()
        {
            ToTable("AT_DoctorLoginInfo");
            HasKey(o => o.Id);
        }
    }
}
