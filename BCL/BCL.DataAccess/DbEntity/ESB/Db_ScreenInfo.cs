using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_ScreenInfo
    {
        public string HospitalId { get; set; }
        public string ScreenId { get; set; }
        public string ScreenName { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
        public string ModDate { get; set; }
        public string ModUser { get; set; }
        public string QuickCode { get; set; }
        //新增跑马灯与视频信息
        public string PromptMsg { get; set; }
        public string Video { get; set; }
        //新增叫号内容信息
        public string CallContent { get; set; }
        //新增叫号次数
        public string CallTimes { get; set; }
    }
    public class Db_ScreenInfoMapper : EntityTypeConfiguration<Db_ScreenInfo>
    {
        public Db_ScreenInfoMapper()
        {
            ToTable("AT_ScreenInfo");
            HasKey(k => new { k.HospitalId, k.ScreenId });
        }
    }
}
