using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_RegPatientList
    {
        public int Id { get; set; }
        public string HospitalId { get; set; }
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string MobilePhoneNo { get; set; }
        public string BusinessId { get; set; }
        public string RegTypeCode { get; set; }
        public string RegTypeName { get; set; }
        public string RegDeptCode { get; set; }
        public string RegDeptName { get; set; }
        public string RegDoctorCode { get; set; }
        public string RegDoctorName { get; set; }
        public DateTime RegDate { get; set; }
        public string RegTime { get; set; }
        public string Number { get; set; }
        public string VisitTime { get; set; }
        public string VisitAddr { get; set; }
        public string ResChannel { get; set; }
        public int IsRes { get; set; }
        public int IsCancel { get; set; }
        public string QueueNo { get; set; }
        public string QueueState { get; set; }
        public DateTime? CheckTime { get; set; }
        public string CheckTypeCode { get; set; }
        public string CheckTypeName { get; set; }
        public string CheckDeptCode { get; set; }
        public string CheckDeptName { get; set; }
        public string CheckDoctorCode { get; set; }
        public string CheckDoctorName { get; set; }
        public DateTime ModDate { get; set; }
        public string ModUser { get; set; }
        public DateTime? CallDate { get; set; }
        public string CallUser { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string SpecFlag { get; set; }
        public string CardInfo1 { get; set; }
        public string CardInfo2 { get; set; }
        public string CardInfo3 { get; set; }
        public string CardInfo4 { get; set; }
        public string CardInfo5 { get; set; }
        public string CardInfo6 { get; set; }
        public string CardInfo7 { get; set; }
        public string CardInfo8 { get; set; }
        public string CardInfo9 { get; set; }
        public string CardInfo10 { get; set; }
        /// <summary>
        /// 0.未评估 1.已评估
        /// </summary>
        public int? IsAssess { get; set; }
    }
    public class Db_RegPatientListMapper : EntityTypeConfiguration<Db_RegPatientList>
    {
        public Db_RegPatientListMapper()
        {
            ToTable("AT_RegPatientList");
            HasKey(k => k.Id);
        }
    }
}
