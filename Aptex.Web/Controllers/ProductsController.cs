using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;
using Aptex.Contracts.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aptex.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        private readonly ICategoriesService categoriesService;

        public ProductsController(
            IProductsService productsService,
            ICategoriesService categoriesService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
        }

        // GET: Products
        public ActionResult Index()
        {
            var viewModel = new ProductsViewModel
            {
                Products = this.productsService
                    .List()
                    .Select(product => new ProductViewModel
                    {
                        ProductName = product.Name,
                        ProductReception = product.Reception,
                        Price = product.Price,
                        Quantity = product.Quantity
                    })
                    .ToList(),

                Categories = this.categoriesService
                    .List()
                    .Select(category => new CategorySelectViewModel
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Selected = false
                    })
                    .ToList()
            };

            return View("Products", viewModel);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost("[controller]/Add")]
        public ActionResult Add(ProductViewModel viewModel)
        {
            productsService.Add(new Product
            {
                Name = viewModel.ProductName,
                Reception = viewModel.ProductReception,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity
            });

            return Redirect("Index");
        }

        /*

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}