using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;

namespace Aptex.Infrastructure.Mock
{
    public class MockRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected HashSet<TEntity> Collection { get; private set; }

        public MockRepository()
        {
            Collection = new HashSet<TEntity>();
        }

        public int Add(TEntity entity)
        {
            Collection.Add(entity);

            return entity.Id;
        }

        public void Delete(TEntity entity)
        {
            Collection.RemoveWhere(ent => ent.Id == entity.Id);
        }

        public void Edit(TEntity entity)
        {
            throw new NotImplementedException();
        }
        
        public bool Save()
        {
            return true;
        }

        public TEntity Get(int id)
        {
            return Collection.FirstOrDefault(entity => entity.Id == id);
        }

        IEnumerable<TEntity> IRepository<TEntity>.List()
        {
            return Collection;
        }
    }
}
