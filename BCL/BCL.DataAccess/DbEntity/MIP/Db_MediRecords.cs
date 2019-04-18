using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.MIP
{
    public class Db_MediRecords
    {
        public int Id { get; set; }
        public string PSNo { get; set; }
        public string IndexId { get; set; }
        public string BillId { get; set; }
        public string MediKind { get; set; }
        public decimal TAmount { get; set; }
        public decimal CAmount { get; set; }
        public decimal RAmount { get; set; }
        public DateTime EffectTime { get; set; }
        public string MediNo { get; set; }
        public DateTime MediDate { get; set; }
        public string ReqNo { get; set; }
        public string Order { get; set; }
        public string ResNo { get; set; }
        public DateTime ResDate { get; set; }
        public string OperCode { get; set; }
        public string OperName { get; set; }
        public string ReconNo { get; set; }
        public int SpecState { get; set; }
        public decimal TYAmount { get; set; }
        public decimal OYAmount { get; set; }
        public decimal OFAmount { get; set; }
        public decimal TEAmount { get; set; }
        public decimal TSAmount { get; set; }
        public decimal TCAmount { get; set; }
        public decimal PEAmount { get; set; }
        public decimal PSAmount { get; set; }
        public decimal PCAmount { get; set; }
        public int MIPState { get; set; }
        public int UPPState { get; set; }
        public int HISState { get; set; }
        public decimal Amount1 { get; set; }
        public decimal Amount2 { get; set; }
        public decimal Amount3 { get; set; }
        public decimal Amount4 { get; set; }
        public decimal Amount5 { get; set; }
        public decimal Amount6 { get; set; }
        public decimal Amount7 { get; set; }
        public decimal Amount8 { get; set; }
        public decimal Amount9 { get; set; }
        public decimal Amount10 { get; set; }
        public decimal Amount11 { get; set; }
        public decimal Amount12 { get; set; }
        public decimal Amount13 { get; set; }
        public decimal Amount14 { get; set; }
        public decimal Amount15 { get; set; }
        public decimal Amount16 { get; set; }
        public decimal Amount17 { get; set; }
        public decimal Amount18 { get; set; }
        public decimal Amount19 { get; set; }
        public decimal Amount20 { get; set; }
        public decimal Amount21 { get; set; }
        public decimal Amount22 { get; set; }
        public decimal Amount23 { get; set; }
        public decimal Amount24 { get; set; }
        public decimal Amount25 { get; set; }
        public decimal Amount26 { get; set; }
        public decimal Amount27 { get; set; }
        public decimal Amount28 { get; set; }
        public decimal Amount29 { get; set; }
        public decimal Amount30 { get; set; }
        public decimal Amount31 { get; set; }
        public decimal Amount32 { get; set; }
        public decimal Amount33 { get; set; }
        public decimal Amount34 { get; set; }
        public decimal Amount35 { get; set; }
        public decimal PICCAmt { get; set; }
        public string PICCInfo { get; set; }
        public string Remarks { get; set; }
        public string AppCode { get; set; }
    }
    public class Db_MediRecordsMapper : EntityTypeConfiguration<Db_MediRecords>
    {
        public Db_MediRecordsMapper()
        {
            ToTable("MI_MediRecords");
            HasKey(x => x.Id);
        }
    }
}
