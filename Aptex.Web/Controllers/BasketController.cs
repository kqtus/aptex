using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;
using Aptex.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aptex.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IMapper mapper;

        private readonly IProductsService productsService;

        private readonly IBasketService basketService;

        private readonly IOrderService orderService;

        public BasketController(
            IMapper mapper,
            IProductsService productsService,
            IBasketService basketService)
        {
            this.mapper = mapper;
            this.productsService = productsService;
            this.basketService = basketService;
            this.orderService = orderService;
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

            basketService.Clear("user1");

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

        [HttpGet]
        public IActionResult Clear()
        {
            orderService.Add(new Order
            {
                ProductsInOrder = basketService
                    .List()
                    .Select(prod => new ProductInOrder
                    {
                        ProductId = prod.Id,
                        Count = prod.Count
                    })
                    .ToList(),
                UserId = "user1"
            });

            basketService.Clear("user1");
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
                    var productViewModel = mapper.Map<ProductViewModel>(product);
                    productViewModel.BasketItemsCount = 1;

                    return productViewModel;
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
                .TotalCost("user1");
            
            return View("Basket", viewModel);
        }
    }
}