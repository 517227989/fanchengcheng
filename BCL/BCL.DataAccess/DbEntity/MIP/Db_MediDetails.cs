using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.MIP
{
    public class Db_MediDetails
    {
        public int Id { get; set; }
        public string IndexId { get; set; }
        public string BillId { get; set; }
        public string ReceiptId { get; set; }
        public string ReceiptType { get; set; }
        public string ReceiptName { get; set; }
        public string DetailId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public DateTime BillDate { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal ItemNum { get; set; }
        public decimal ItemAmount { get; set; }
        public string BillDeptCode { get; set; }
        public string BillDeptName { get; set; }
        public string BillDoctorCode { get; set; }
        public string BillDoctorName { get; set; }
        public string ItemClassifyCode { get; set; }
        public string ItemClassifyName { get; set; }
        public string ItemPlaceCode { get; set; }
        public string ItemPlaceName { get; set; }
        public string ItemFormat { get; set; }
        public string ItemUnit { get; set; }
        public string ItemDosage { get; set; }
        public string DayNum { get; set; }
        public string DayDosage { get; set; }
        public string UploadNo { get; set; }
        public string MediDays { get; set; }
        public string MediNum { get; set; }
        public string MediLevel { get; set; }
        public string MediCode { get; set; }
        public string MediName { get; set; }
        public decimal ItemPayRatio { get; set; }
        public string ConverRatio { get; set; }
        public decimal SelfPayPrice { get; set; }
        public decimal SelfCarePrice { get; set; }
        public decimal SelfChargeAmount { get; set; }
        public decimal OverLimitSelfPayAmount { get; set; }
        public decimal OverLimitReasonCode { get; set; }
        public string OverLimitReasonDetail { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonDetail { get; set; }
        public DateTime AddDate { get; set; }
        public int ForcedSelf { get; set; }
        public int IsComp { get; set; }
        public string DeaICD { get; set; }
        public string DeaDES { get; set; }
        public string DeaCode { get; set; }
        public string DeaName { get; set; }
        public string Remarks { get; set; }
    }
    public class Db_MediDetailsMapper : EntityTypeConfiguration<Db_MediDetails>
    {
        public Db_MediDetailsMapper()
        {
            ToTable("MI_MediDetails");
            HasKey(x => x.Id);
        }
    }
}
