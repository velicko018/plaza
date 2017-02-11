using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Plaza.Models
{
    public class Room
    {
        public ObjectId Id { get; set; }

        [BsonElement("roomNumber")]
        public int RoomNumber { get; set; }

        [BsonElement("roomFloor")]
        public int RoomFloor { get; set; }

        [BsonElement("roomType")]
        public RoomType roomType{ get; set; }

        [BsonElement("reservations")]
        public List<Reservation> Reservations { get; set; }
    }
}
