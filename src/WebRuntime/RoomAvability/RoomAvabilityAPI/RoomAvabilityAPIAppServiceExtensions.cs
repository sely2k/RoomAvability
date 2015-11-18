using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace RoomAvability
{
    public static class RoomAvabilityAPIAppServiceExtensions
    {
        public static RoomAvabilityAPI CreateRoomAvabilityAPI(this IAppServiceClient client)
        {
            return new RoomAvabilityAPI(client.CreateHandler());
        }

        public static RoomAvabilityAPI CreateRoomAvabilityAPI(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new RoomAvabilityAPI(client.CreateHandler(handlers));
        }

        public static RoomAvabilityAPI CreateRoomAvabilityAPI(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new RoomAvabilityAPI(uri, client.CreateHandler(handlers));
        }

        public static RoomAvabilityAPI CreateRoomAvabilityAPI(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new RoomAvabilityAPI(rootHandler, client.CreateHandler(handlers));
        }
    }
}
