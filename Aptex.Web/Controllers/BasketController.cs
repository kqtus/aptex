using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;
using Aptex.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            return Basket();
        }

        [HttpPost]
        public IActionResult Index(BasketSummaryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Basket(viewModel);
            }

            basketService.Clear();

            return View("Success");
        }

        [HttpPost]
        public IActionResult RemoveItem(BasketSummaryViewModel viewModel, int productId)
        {
            var pb = basketService.List().FirstOrDefault(bp => bp.ProductId == productId);

            if (pb != null)
            {
                basketService.Remove(pb);
            }

            return Redirect("Index");
        }

        protected IActionResult Basket(BasketSummaryViewModel viewModel = null)
        {
            if (viewModel == null)
            {
                viewModel = new BasketSummaryViewModel();
            }

            viewModel.Products = this.basketService
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
                .ToList();

            viewModel.DeliveryOptions = new List<SelectListItem>()
            {
                new SelectListItem("Kurier DPD", "1"),
                new SelectListItem("Kurier Pocztex", "2"),
                new SelectListItem("Poczta Polska", "3"),
                new SelectListItem("Paczkomaty", "4"),
            };

            viewModel.PaymentOptions = new List<SelectListItem>()
            {
                new SelectListItem("Przy odbiorze", "1"),
                new SelectListItem("Kartą", "2"),
                new SelectListItem("Przelewem", "3"),
                new SelectListItem("BLIK", "4"),
            };
            
            viewModel.TotalPrice = this.basketService
                .TotalCost();
            
            return View("Basket", viewModel);
        }
    }
}