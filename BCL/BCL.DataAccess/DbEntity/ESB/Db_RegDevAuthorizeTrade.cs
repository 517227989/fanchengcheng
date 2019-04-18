using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_RegDevAuthorizeTrade
    {
        public int Id { get; set; }
        public string RegDevCode { get; set; }
        public string AuthorizeHospitalCode { get; set; }
        public string AddDate { get; set; }
        public string AddOper { get; set; }
        public string TradeType { get; set; }
    }
    public class Db_RegDevAuthorizeTradeMapper : EntityTypeConfiguration<Db_RegDevAuthorizeTrade>
    {
        public Db_RegDevAuthorizeTradeMapper()
        {
            ToTable("AT_RegDevAuthorizeTrade");
            HasKey(o => o.Id);
        }
    }
}
