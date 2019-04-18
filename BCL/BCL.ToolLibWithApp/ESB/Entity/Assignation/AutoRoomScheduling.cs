using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Assignation
{
    public class ExternalReqAutoRoomScheduling : ExternalReqBase
    {
        public String Time { get; set; }
        public String RoomId { get; set; }
        public String NStationId { get; set; }
    }
    public class ExternalResAutoRoomScheduling : ExternalResBase
    {

    }
}
