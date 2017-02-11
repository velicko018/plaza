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

    public class RoomRepository : IRepository<Room>
    {
        private readonly Settings settings;
        private readonly IMongoDatabase database;
        public IEnumerable<Room> All()
        {
            return database
                .GetCollection<Room>("rooms")
                .Find(x => true)
                .ToList();
        }

        public Room GetById(ObjectId id)
        {
            return database.GetCollection<Room>("rooms")
                .Find(x => x.Id == id)
                .Single();
        }

        public void Add(Room room)
        {
            database.GetCollection<Room>("rooms")
                .InsertOneAsync(room);
        }

        public void Update(Room room)
        {
            database.GetCollection<Room>("rooms")
                .ReplaceOne(x => x.Id == room.Id, room);
        }

        public bool Remove(ObjectId id)
        {
            database.GetCollection<Room>("rooms")
                .DeleteOne(x => x.Id == id);
            return GetById(id) == null;
        }

        public RoomRepository(IOptions<Settings> settings)
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
