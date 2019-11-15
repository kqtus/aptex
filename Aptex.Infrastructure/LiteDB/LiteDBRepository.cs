using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.LiteDB.Data;
using LiteDB;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;

namespace Aptex.Infrastructure.LiteDB
{
    public class LiteDBRepository<T> : IRepository<T> where T : Entity
    {
        protected LiteCollection<T> Collection { get; }
        
        public LiteDBRepository(ILiteDbContext ctx)
        {
            Collection = ctx.LiteDatabase.GetCollection<T>();
        }

        public virtual T Get(int id)
        {
            return Collection.FindById(id);
        }

        public virtual IEnumerable<T> List()
        {
            return Collection.FindAll();
        }

        public virtual int Add(T entity)
        {
            return (int)Collection.Insert(entity);
        }

        public virtual void Delete(T entity)
        {
            Collection.Delete(new BsonValue(entity.Id));
        }

        public virtual void Edit(T entity)
        {
            Collection.Update(entity);
        }

        public bool Save()
        {
            return true;
        }
    }
}
