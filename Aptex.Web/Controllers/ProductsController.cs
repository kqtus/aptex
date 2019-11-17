using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper mapper;

        private readonly IProductsService productsService;

        private readonly IBasketService basketService;

        private readonly ICategoriesService categoriesService;

        public ProductsController(
            IMapper mapper,
            IProductsService productsService,
            IBasketService basketService,
            ICategoriesService categoriesService)
        {
            this.mapper = mapper;
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
                    .Select(product => mapper.Map<ProductViewModel>(product))
                    .ToList(),

                Categories = vm.Categories.Count == 0 
                    ? this.categoriesService
                        .List()
                        .Select(category => mapper.Map<CategorySelectViewModel>(category))
                        .ToList()
                    : vm.Categories
            };

            return View("Products", viewModel);
        }
        
        public ActionResult Add()
        {
            var viewModel = new ProductViewModel();
            AppendProductCategories(viewModel);

            return View(viewModel);
        }

        protected void AppendProductCategories(ProductViewModel viewModel)
        {
            viewModel.Categories = categoriesService.List()
                .Select(cat => new SelectListItem(cat.Name, cat.Id.ToString()))
                .ToList();
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            productsService.Add(mapper.Map<Product>(viewModel));

            return Redirect("Index");
        }

        public ActionResult Edit()
        {
            var viewModel = new ProductEditViewModel();
            AppendEditableProducts(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SelectToEdit(ProductEditViewModel viewModel)
        {
            var product = productsService.Get(viewModel.SelectedProductId);
            viewModel.SelectedProduct = mapper.Map<ProductViewModel>(product);
            
            AppendEditableProducts(viewModel);
            AppendProductCategories(viewModel.SelectedProduct);

            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                AppendEditableProducts(viewModel);
                return View(viewModel);
            }

            var modifiedProduct =
                mapper.Map(viewModel.SelectedProduct, productsService.Get(viewModel.SelectedProductId));

            productsService.Update(modifiedProduct);

            AppendEditableProducts(viewModel);
            AppendProductCategories(viewModel.SelectedProduct);
            
            return View(viewModel);
        }

        protected void AppendEditableProducts(ProductEditViewModel viewModel)
        {
            viewModel.Products = productsService
                .List()
                .Select(product => new SelectListItem(product.Name, product.Id.ToString()))
                .ToList();
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