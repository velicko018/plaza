using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Plaza.Models
{
    public class Room
    {
        public ObjectId Id { get; set; }
        public int RoomNumbere { get; set; }
        public int RoomFloor { get; set; }
        public int RoomType { get; set; }
    }
}
