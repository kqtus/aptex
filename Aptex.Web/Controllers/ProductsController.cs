using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;
using Aptex.Contracts.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Aptex.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        private readonly IBasketService basketService;

        private readonly ICategoriesService categoriesService;

        public ProductsController(
            IProductsService productsService,
            IBasketService basketService,
            ICategoriesService categoriesService)
        {
            this.productsService = productsService;
            this.basketService = basketService;
            this.categoriesService = categoriesService;
        }

        // GET: Products
        public ActionResult Index(ProductsViewModel vm)
        {
            var selectedCategories = vm.Categories.Where(cat => cat.Selected);

            var viewModel = new ProductsViewModel
            {
                Products = this.productsService
                    .List()
                    .Where(product => selectedCategories.Count() == 0
                        || selectedCategories.Any(cat => cat.Id == product.CategoryId))
                    .Select(product => new ProductViewModel
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        ProductReception = product.Reception,
                        Price = product.Price,
                        Quantity = product.Quantity
                    })
                    .ToList(),

                Categories = vm.Categories.Count == 0 
                    ? this.categoriesService
                        .List()
                        .Select(category => new CategorySelectViewModel
                        {
                            Id = category.Id,
                            Name = category.Name,
                            Selected = false
                        })
                        .ToList()
                    : vm.Categories
            };

            return View("Products", viewModel);
        }
        
        public ActionResult Add()
        {
            var viewModel = new ProductViewModel
            {
                Categories = categoriesService.List()
                    .Select(cat => new SelectListItem(cat.Name, cat.Id.ToString()))
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            productsService.Add(new Product
            {
                Name = viewModel.ProductName,
                Reception = viewModel.ProductReception,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity,
                CategoryId = viewModel.CategoryId
            });

            return Redirect("Index");
        }


        [HttpPost]
        public ActionResult AddToBasket(ProductViewModel viewModel)
        {
            basketService.Add(new ProductInBasket
            {
                ProductId = viewModel.ProductId,
                UserId = "user1",
                Count = 1
            });

            return Redirect("Index");
        }
    }
}