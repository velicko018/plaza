using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Plaza.Models
{
    public class RoomType
    {
        public ObjectId Id { get; set; }
        public int MaxGuests { get; set; }
        public string Name { get; set; }
        public int TotalRooms { get; set; }
        public int RoomPrice { get; set; }
        public string Description { get; set; }

    }
}
