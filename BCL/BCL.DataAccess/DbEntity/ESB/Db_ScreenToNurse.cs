using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_ScreenToNurse
    {
        public int Id { get; set; }
        public string ScreenId { get; set; }
        public string NurseStationId { get; set; }
        public DateTime? ModDate { get; set; }
        public string ModUser { get; set; }
    }
    public class Db_ScreenToNurseMapper : EntityTypeConfiguration<Db_ScreenToNurse>
    {
        public Db_ScreenToNurseMapper()
        {
            ToTable("ct_screentonurse");
            HasKey(k => new { k.Id });
        }
    }
}
