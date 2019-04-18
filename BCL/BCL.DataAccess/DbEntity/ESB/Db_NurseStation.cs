using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_NurseStation
    {
        public string HospitalId { get; set; }
        public int Id { get; set; }
        public string NurseStationId { get; set; }
        public string StationName { get; set; }
        public int State { get; set; }
        public string QuickCode { get; set; }
        public DateTime ModDate { get; set; }
        public string ModUser { get; set; }
    }
    public class Db_NurseStationMapper : EntityTypeConfiguration<Db_NurseStation>
    {
        public Db_NurseStationMapper()
        {
            ToTable("AT_NurseStation");
            HasKey(k => new { k.Id });
        }
    }
}
