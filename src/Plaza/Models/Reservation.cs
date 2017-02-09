using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Plaza.Models
{
    public class Reservation
    {
        public int NumberOfGuests { get; set; }
        public int RoomNumber { get; set; }
        public string UserId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public bool Status { get; set; }
        public ObjectId Id { get; set; }
    }
}
