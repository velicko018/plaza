using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using MongoDB.Bson;

namespace Plaza.Repositories
{
    public interface IRepository<T> 
    {
        IEnumerable<T> All();

        T GetById(ObjectId id);

        void Add(T t);

        void Update(T t);

        bool Remove(ObjectId id);
    }
}