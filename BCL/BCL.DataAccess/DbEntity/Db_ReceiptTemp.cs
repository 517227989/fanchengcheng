using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess
{
    public class Db_ReceiptTemp
    {
        public int Id { get; set; }
        public string HospitalId { get; set; }
        public int LineNum { get; set; }
        public string TempCode { get; set; }
        public string TempName { get; set; }
        public string VarCode { get; set; }
        public string VarName { get; set; }
        public string VarValue { get; set; }
        public string StyleMark { get; set; }
        public int TempType { get; set; }
    }
}
