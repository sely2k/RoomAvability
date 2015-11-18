using RoomAvabilityAPI.EWS;
using RoomAvabilityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace RoomAvabilityAPI.Controllers
{
    public class RoomAvabilityController : ApiController
    {


        [HttpGet]
        public IEnumerable<RoomAvability> Get()
        {
            try
            {

                string username = WebConfigurationManager.AppSettings["RAusername"];
                string password = WebConfigurationManager.AppSettings["RApassword"];
                string roomname = WebConfigurationManager.AppSettings["RoomName"];

                EwsRoomAvability roomAvability = new EwsRoomAvability(username, password);

                var avability = roomAvability.getAvability(roomname);
                RoomAvability[] roomAvabilityArray = avability.ToArray<RoomAvability>();
                //return ggg;

                return roomAvabilityArray;

            }
            catch(Exception ex)
            {
                return null;
            }




        }

    }
}