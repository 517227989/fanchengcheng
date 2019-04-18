using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
   public class Db_ExamPatient
    {
        public int Id { get; set; }
        public string HospitalId { get; set; }
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string MobilePhoneNo { get; set; }       
        public string BusinessId { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; } 
        public string Number { get; set; }
        public string VisitTime { get; set; }
        public string VisitAddr { get; set; }
        public string ResChannel { get; set; }        
        public int IsCancel { get; set; }
        public string QueueNo { get; set; }
        public string QueueState { get; set; }
        public DateTime? CheckTime { get; set; }      
        public string CheckDeptCode { get; set; }
        public string CheckDeptName { get; set; } 
        public DateTime? ModDate { get; set; }
        public string ModUser { get; set; }
        public DateTime? CallDate { get; set; }
        public string CallUser { get; set; }
        public string RoomId { get; set; }     
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
    }
    public class Db_ExamPatientMapper : EntityTypeConfiguration<Db_ExamPatient>
    {
        public Db_ExamPatientMapper()
        {
            ToTable("at_exampatientlist");
            HasKey(k => k.Id);
        }
    }
}
