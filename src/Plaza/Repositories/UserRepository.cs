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
    
    public class UserRepository: IRepository<User>
    {
        private readonly IOptions<Settings> settings;
        private readonly IMongoDatabase database;
        public IEnumerable<User> All()
        {
            return database
                .GetCollection<User>("users")
                .Find(new BsonDocument())
                .ToList();

        }

        public User GetById(ObjectId id)
        {
            return database.GetCollection<User>("users")
                .Find(x => x.Id == id)
                .Single();
        }

        public void Add(User t)
        {
            database.GetCollection<User>("users")
                .InsertOneAsync(t);
        }

        public void Update(User t)
        {
            database.GetCollection<User>("users")
                .ReplaceOne(x => x.Id == t.Id, t);
        }

        public bool Remove(ObjectId id)
        {
            database.GetCollection<User>("users")
                .DeleteOne(x => x.Id == id);
            return GetById(id) == null;
        }

        public UserRepository(IOptions<Settings> settings)
        {
            this.settings = settings;
            database = Connect();
        }

        private IMongoDatabase Connect()
        {
            var client = new MongoClient(settings.Value.MongoConnection);
            var database = client.GetDatabase(settings.Value.Database);

            return database;
        }
    }
   
}
