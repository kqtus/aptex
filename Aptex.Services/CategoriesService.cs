using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;

namespace Aptex.Services
{
    public class CategoriesService : CrudService<Category>, ICategoriesService
    {
        public CategoriesService(IRepository<Category> repo)
            : base(repo)
        {
        }
    }
}
