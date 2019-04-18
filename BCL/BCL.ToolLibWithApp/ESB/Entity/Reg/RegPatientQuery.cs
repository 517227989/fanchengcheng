using BCL.DataAccess.DbEntity.ESB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Reg
{
    public class ExternalReqRegPatientQuery : ExternalReqBase
    {
        public string BngDate { get; set; }
        public string EndDate { get; set; }
    }
    public class ExternalResRegPatientQuery : ExternalResBase
    {
        public ExternalResRegPatientQuery()
        {
            RegPatientList = new List<Db_RegPatientList>();
        }
        public List<Db_RegPatientList> RegPatientList { get; set; }
    }
}
