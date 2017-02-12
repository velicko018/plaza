using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Plaza.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        
        [BsonElement("firstName")]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [BsonElement("email")]
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [BsonElement("password")]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [BsonElement("phoneNumber")]
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [BsonElement("reservations")]
        public List<Reservation> Reservations { get; set; }

        [BsonElement("admin")]
        public bool Admin { get; set; }
    }
}
