using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using MongoDB.Driver.Linq;

using Plaza.Models;

namespace Plaza.Repositories
{

    public class ReservationRepository : IRepository<Reservation>
    {
        private readonly Settings settings;
        private readonly IMongoDatabase database;
        public IEnumerable<Reservation> All()
        {
            return database
                .GetCollection<Reservation>("reservations")
                .Find(x => true)
                .ToList();
        }

        public Reservation GetById(ObjectId id)
        {
            return database.GetCollection<Reservation>("reservations")
                .Find(x => x.Id == id)
                .Single();
        }

        public void Add(Reservation reservation)
        {
            database.GetCollection<Reservation>("reservations")
                .InsertOneAsync(reservation);
        }

        public void Update(Reservation reservation)
        {
            database.GetCollection<Reservation>("reservations")
                .ReplaceOne(x => x.Id == reservation.Id, reservation);
        }

        public bool Remove(ObjectId id)
        {
            database.GetCollection<Reservation>("reservations")
                .DeleteOne(x => x.Id == id);
            return GetById(id) == null;
        }

        public ReservationRepository(IOptions<Settings> settings)
        {
            this.settings = settings.Value;
            database = Connect();
        }

        private IMongoDatabase Connect()
        {
            var client = new MongoClient(settings.MongoConnection);
            var database = client.GetDatabase(settings.Database);

            return database;
        }
    }

}
