using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;
using Aptex.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Aptex.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductsService productsService;

        private readonly IBasketService basketService;

        public BasketController(
            IProductsService productsService,
            IBasketService basketService)
        {
            this.productsService = productsService;
            this.basketService = basketService;
        }

        public IActionResult Index()
        {
            var viewModel = new BasketSummaryViewModel()
            {
                Products = this.basketService
                    .List()
                    .Select(basketProduct =>
                    {
                        var product = productsService.Get(basketProduct.ProductId);

                        return new ProductViewModel
                        {
                            ProductName = product.Name,
                            ProductReception = product.Reception,
                            Price = product.Price,
                            Quantity = product.Quantity,
                            BasketItemsCount = 1
                        };
                    })
                    .ToList()
            };
            
            return View("Basket", viewModel);
        }

        [HttpPost]
        public IActionResult Index(BasketSummaryViewModel viewModel)
        {
            return View("Success");
        }
    }
}