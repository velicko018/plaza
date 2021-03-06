﻿using System;
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
        private readonly Settings settings;
        private readonly IMongoDatabase database;
        public IEnumerable<User> All()
        {
            return database
                .GetCollection<User>("users")
                .Find(x => true)
                .ToList();
        }

        public User GetById(ObjectId id)
        {
            return database.GetCollection<User>("users")
                .Find(x => x.Id == id)
                .Single();
        }

        public User GetUser(string email, string password)
        {
            return database.GetCollection<User>("users")
                .Find(x => x.Email == email && x.Password == password)
                .Single();
        }

        public void Add(User user)
        {
            database.GetCollection<User>("users")
                .InsertOneAsync(user);
        }

        public void Update(User user)
        {
            database.GetCollection<User>("users")
                .ReplaceOne(x => x.Id == user.Id, user);
        }

        public bool Remove(ObjectId id)
        {
            database.GetCollection<User>("users")
                .DeleteOne(x => x.Id == id);
            return GetById(id) == null;
        }

        public UserRepository(IOptions<Settings> settings)
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
