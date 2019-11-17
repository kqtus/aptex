using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;

namespace Aptex.Services
{
    public class BasketService : CrudService<ProductInBasket>, IBasketService
    {
        private readonly IProductsService productsService;

        public BasketService(
            IRepository<ProductInBasket> repo,
            IProductsService productsService)
            : base(repo)
        {
            this.productsService = productsService;
        }

        public int ItemsCount(string userId)
        {
            return this._repo
                .List()
                .Where(prod => prod.UserId.Equals(userId))
                .Select(prod => prod.Count)
                .Sum();
        }

        public decimal TotalCost(string userId)
        {
            return this._repo
                .List()
                .Where(prod => prod.UserId.Equals(userId))
                .Select(pib => new
                {
                    Product = this.productsService.Get(pib.ProductId),
                    pib.Count
                })
                .Select(prodAndCount => prodAndCount.Product.Price * prodAndCount.Count)
                .Sum();
        }

        public void Clear(string userId)
        {
            var products = this._repo
                .List()
                .Where(prod => prod.UserId.Equals(userId))
                .ToList();

            foreach (var prod in products)
            {
                this._repo.Delete(prod);
            }
        }
    }
}
