using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Aptex.Contracts.Models;

namespace Aptex.Contracts.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Get(int id);

        IEnumerable<TEntity> List();

        int Add(TEntity entity);

        void Delete(TEntity entity);

        void Edit(TEntity entity);

        bool Save();
    }
}