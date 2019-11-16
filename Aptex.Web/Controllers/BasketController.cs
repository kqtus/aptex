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
                            ProductId = product.Id,
                            ProductName = product.Name,
                            ProductReception = product.Reception,
                            Price = product.Price,
                            Quantity = product.Quantity,
                            BasketItemsCount = 1
                        };
                    })
                    .ToList(),

                TotalPrice = this.basketService
                    .TotalCost()
            };
            
            return View("Basket", viewModel);
        }

        [HttpPost]
        public IActionResult Index(BasketSummaryViewModel viewModel)
        {
            basketService.Clear();

            return View("Success");
        }

        [HttpPost]
        public IActionResult RemoveItem(int productId)
        {
            var pb = basketService.List().FirstOrDefault(bp => bp.ProductId == productId);

            if (pb != null)
            {
                basketService.Remove(pb);
            }

            return Redirect("Index");
        }
    }
}