using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Text;

namespace RoomAvability.Models
{
    public partial class RoomAvabilityModel
    {
        public string MeetingDuration
        {
            get
            {
                //return (EndTime - StartTime).Value.Minutes;
                var diff = (EndTime - StartTime).Value;


                if (diff.Hours > 0)
                {
                    StringBuilder str = new StringBuilder();
                    str.AppendFormat("{0}h", diff.Hours);
                    if (diff.Minutes >0)
                    {
                        str.AppendFormat(" {0}'", diff.Minutes);
                    }
                    return str.ToString();
                }
                else
                {
                    return string.Format("{0}'", diff.TotalMinutes);
                }
            }
        }
    }
}
