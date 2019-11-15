using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;

namespace Aptex.Services
{
    public class CrudService<TEntity> : ICrudService<TEntity> where TEntity : Entity
    {
        protected IRepository<TEntity> _repo;

        public CrudService(IRepository<TEntity> repo)
        {
            _repo = repo;
        }

        public virtual int Add(TEntity entity)
        {
            int id = _repo.Add(entity);
            _repo.Save();

            return id;
        }

        public TEntity Get(int entityId)
        {
            return _repo.Get(entityId);
        }

        public virtual void Remove(TEntity entity)
        {
            _repo.Delete(entity);
            _repo.Save();
        }

        public virtual bool Update(TEntity entity)
        {
            _repo.Edit(entity);

            return _repo.Save();
        }

        public virtual IEnumerable<TEntity> List()
        {
            return _repo.List();
        }
    }
}
