using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Plaza.Models
{
    public class Reservation
    {
        public ObjectId Id { get; set; }

        [BsonElement("user")]
        public User User { get; set; }

        [BsonElement("room")]
        public Room Room { get; set; }

        [BsonElement("numberOfGuests")]
        public int NumberOfGuests { get; set; }

        [BsonElement("arrivalDate")]
        public DateTime ArrivalDate { get; set; }

        [BsonElement("departureDate")]
        public DateTime DepartureDate { get; set; }

        [BsonElement("status")]
        public bool Status { get; set; }
    }
}
