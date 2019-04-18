using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.MIP
{
    public class Db_MediPersons : Db_Base
    {
        public string Sex { get; set; }
        public string Name { get; set; }
        public string IndexId { get; set; }
        public string Nation { get; set; }
        public string MediKind { get; set; }
        public string MediIndex { get; set; }
        public string PersonNo { get; set; }
        public string IdCardNo { get; set; }
        public string WorkNature { get; set; }
        public DateTime Birthday { get; set; }
        public string WorkAddress { get; set; }
        public string DistrctCode { get; set; }
        public string DistrctName { get; set; }
        public string InsurKind { get; set; }
        public string HonorKind { get; set; }
        public string SpecState { get; set; }
        public string SpecCode { get; set; }
        public string BeHospitalNum { get; set; }
        public string ThisYearBalance { get; set; }
        public string OverYearBalance { get; set; }
        public string ThisYearIncludeCoord { get; set; }
        public string PinCode { get; set; }
        public string CardInfo { get; set; }
        public string TreatType { get; set; }
    }
    public class Db_MediPersonsMapper : EntityTypeConfiguration<Db_MediPersons>
    {
        public Db_MediPersonsMapper()
        {
            ToTable("MI_MediPersons");
            HasKey(o => o.Id);
        }
    }
}
