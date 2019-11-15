using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;

namespace Aptex.Services
{
    public class ProductsService : CrudService<Product>, IProductsService
    {
        public ProductsService(IRepository<Product> repo)
            : base(repo)
        {
        }

        public List<Product> ListByCategories(List<int> categoryIds)
        {
            return this._repo
                .List()
                .Where(x => categoryIds.Contains(x.CategoryId))
                .ToList();
        }
    }
}
