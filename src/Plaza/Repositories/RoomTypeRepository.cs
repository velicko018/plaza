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

    public class RoomTypeRepository : IRepository<RoomType>
    {
        private readonly Settings settings;
        private readonly IMongoDatabase database;
        public IEnumerable<RoomType> All()
        {
            return database
                .GetCollection<RoomType>("roomTypes")
                .Find(x => true)
                .ToList();
        }

        public RoomType GetById(ObjectId id)
        {
            return database.GetCollection<RoomType>("roomTypes")
                .Find(x => x.Id == id)
                .Single();
        }

        public void Add(RoomType roomTypes)
        {
            database.GetCollection<RoomType>("roomTypes")
                .InsertOneAsync(roomTypes);
        }

        public void Update(RoomType roomTypes)
        {
            database.GetCollection<RoomType>("roomTypes")
                .ReplaceOne(x => x.Id == roomTypes.Id, roomTypes);
        }

        public bool Remove(ObjectId id)
        {
            database.GetCollection<RoomType>("roomTypes")
                .DeleteOne(x => x.Id == id);
            return GetById(id) == null;
        }

        public RoomTypeRepository(IOptions<Settings> settings)
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
