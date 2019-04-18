using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_EmpiDetails
    {
        public String EmpiId { get; set; }
        public String HospitalCode { get; set; }
        public String HospitalName { get; set; }
        public String Name { get; set; }
        public Int32 SexCode { get; set; }
        public String SexName { get; set; }
        public String PaperType { get; set; }
        public String PaperName { get; set; }
        public String PaperNum { get; set; }
        public DateTime Birthday { get; set; }
        public String CountryCode { get; set; }
        public String CountryName { get; set; }
        public String NationCode { get; set; }
        public String NationName { get; set; }
        public String MaritalCode { get; set; }
        public String MaritalName { get; set; }
        public String EduLevelCode { get; set; }
        public String EduLevelName { get; set; }
        public String BirthPlaceCode { get; set; }
        public String BirthPlaceName { get; set; }
        public String PhoneNum { get; set; }
        public String MobillePhone { get; set; }
        public String Email { get; set; }
        public String MailingAddress { get; set; }
        public String CensusAddressCode { get; set; }
        public String CensusAddressName { get; set; }
        public String CensusZipCode { get; set; }
        public String LiveAdressCode { get; set; }
        public String LiveAdressName { get; set; }
        public String LiveAdressDetails { get; set; }
        public String LiveAdressZipCode { get; set; }
        public String WorkAddress { get; set; }
        public String WorkName { get; set; }
        public String WorkZipCode { get; set; }
        public DateTime? InWorkDate { get; set; }
        public String ProfessionCode { get; set; }
        public String ProfessionName { get; set; }
        public String InsuranceCode { get; set; }
        public String InsuranceName { get; set; }
        public String ContactsName { get; set; }
        public String Relation { get; set; }
        public String ContactsPhone { get; set; }
        public String ContactsAddress { get; set; }
        public DateTime AddDate { get; set; }
        public Int32 Invalid { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Int32 ModFlag { get; set; }
        public Int32 MasterFlag { get; set; }
        public String AreaCode { get; set; }
        public String AreaName { get; set; }
        public String Note { get; set; }
    }
    public class Db_EmpiDetailsMapper : EntityTypeConfiguration<Db_EmpiDetails>
    {
        public Db_EmpiDetailsMapper()
        {
            ToTable("ST_EmpiDetails");
            HasKey(o => o.EmpiId);
        }
    }
}
