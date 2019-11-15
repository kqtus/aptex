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

        public List<Product> List()
        {
            /*
            return new List<Product>
            {
                new Product
                {
                    Name = "Rutinoscorbin",
                    Reception = "Take two pills every 2 hours.",
                    Price = 10.30M,
                    Quantity = "30szt."
                },
                new Product
                {
                    Name = "Marsjanki",
                    Reception = "Don't take them at all",
                    Price = 20.30M,
                    Quantity = "50szt."
                }
            };
            */
            return this._repo
                .List()
                .ToList();
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
