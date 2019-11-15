using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Models;

namespace Aptex.Contracts.Interfaces
{
    public interface ICrudService<TEntity> where TEntity : Entity
    {
        int Add(TEntity entity);

        void Remove(TEntity entity);

        bool Update(TEntity entity);

        TEntity Get(int entityId);

        IEnumerable<TEntity> List();
    }
}
