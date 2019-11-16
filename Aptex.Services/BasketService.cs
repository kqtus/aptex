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

        public int ItemsCount()
        {
            return this._repo
                .List()
                .Select(prod => prod.Count)
                .Sum();
        }

        public decimal TotalCost()
        {
            return this._repo
                .List()
                .Select(pib => this.productsService.Get(pib.ProductId))
                .Select(prod => prod.Price)
                .Sum();
        }

        public void Clear()
        {
            var products = this._repo.List();

            foreach (var prod in products)
            {
                this._repo.Delete(prod);
            }
        }
    }
}
