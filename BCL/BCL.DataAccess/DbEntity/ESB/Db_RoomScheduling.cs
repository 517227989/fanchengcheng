using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_RoomScheduling
    {
        public int Id { get; set; }
        public string HospitalId { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string Week { get; set; }
        public string Time { get; set; }
        public DateTime ModDate { get; set; }
        public string ModUser { get; set; }
        public string TypeCode1 { get; set; }
        public string TypeName1 { get; set; }
        public string DeptCode1 { get; set; }
        public string DeptName1 { get; set; }
        public string DoctorCode1 { get; set; }
        public string DoctorName1 { get; set; }
        public string TypeCode2 { get; set; }
        public string TypeName2 { get; set; }
        public string DeptCode2 { get; set; }
        public string DeptName2 { get; set; }
        public string DoctorCode2 { get; set; }
        public string DoctorName2 { get; set; }
    }
    public class Db_RoomSchedulingMapper : EntityTypeConfiguration<Db_RoomScheduling>
    {
        public Db_RoomSchedulingMapper()
        {
            ToTable("AT_RoomScheduling");
            HasKey(k => k.Id);
        }
    }
}
