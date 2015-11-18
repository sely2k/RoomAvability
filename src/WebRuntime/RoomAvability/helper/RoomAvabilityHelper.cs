using RoomAvability.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAvability.helper
{
    public class RoomAvabilityHelper
    {
        public static string GetFreeBusy(List<RoomAvabilityModel> lst)
        {
            if (lst != null && lst.Count > 0 && (lst.FirstOrDefault().StartTime - DateTime.Now).Value.TotalMinutes < 30)
            {
                return "Busy";
            }
            return "Free";
        }




        public static List<RoomAvabilityModel> getListOfAvability(List<RoomAvabilityModel> lst)
        {
            return lst.Where(e => e.EndTime >= DateTime.Now).OrderBy(s => s.StartTime).ToList();
        }
    }
}
