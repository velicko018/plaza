using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Plaza.Models
{
    public class RoomType
    {
        public ObjectId Id { get; set; }

        [BsonElement("maxGuests")]
        public int MaxGuests { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("totalRooms")]
        public int TotalRooms { get; set; }

        [BsonElement("roomPrice")]
        public int RoomPrice { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

    }
}
