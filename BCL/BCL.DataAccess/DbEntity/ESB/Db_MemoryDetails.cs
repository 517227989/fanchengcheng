﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.ESB
{
    public class Db_MemoryDetails
    {
        public Int32 Id { get; set; }
        public String HospitalId { get; set; }
        public String ServerIp { get; set; }
        public DateTime AddDate { get; set; }
        public String Year { get; set; }
        public String Month { get; set; }
        public String Day { get; set; }
        public String Hour { get; set; }
        public String Minute { get; set; }
        public String UsedAmount { get; set; }
        public String Physical { get; set; }
    }
    public class Db_MemoryDetailsMapper : EntityTypeConfiguration<Db_MemoryDetails>
    {
        public Db_MemoryDetailsMapper()
        {
            ToTable("MT_MemoryDetails");
            HasKey(h => h.Id);
        }
    }
}
