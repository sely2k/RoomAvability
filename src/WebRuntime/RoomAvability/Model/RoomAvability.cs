using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAvability.Model
{
    public class RoomAvability
    {
        public DateTime EndTime { get; set; }
        public string FreeBusyStatus { get; set; }
        public bool IsMeeting { get; set; }
        public bool IsPrivate { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public string Subject { get; set; }
    }
}
