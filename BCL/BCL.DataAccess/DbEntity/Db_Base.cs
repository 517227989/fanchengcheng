using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCL.DataAccess
{
    public class Db_Base
    {
        public int Id { get; set; }
        public string OperCode { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime? ModDate { get; set; }
        public string Remarks { get; set; }
    }
}
