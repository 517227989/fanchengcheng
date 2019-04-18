using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_RoomInfo
    {
        public string HospitalId { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
        public string ScreenId { get; set; }
        public string ScreenName { get; set; }
        public DateTime? ModDate { get; set; }
        public string ModUser { get; set; }
        public string NStationId { get; set; }
        public string PromptMsg { get; set; }
        public int IsCall { get; set; }
    }
    public class Db_RoomInfoMapper : EntityTypeConfiguration<Db_RoomInfo>
    {
        public Db_RoomInfoMapper()
        {
            ToTable("AT_RoomInfo");
            HasKey(k => new { k.HospitalId, k.RoomId });
        }
    }
}
