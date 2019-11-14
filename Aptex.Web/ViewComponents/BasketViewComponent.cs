using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Aptex.Web.ViewComponents
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly IBasketService basketService;

        public BasketViewComponent(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new BasketViewModel
            {
                ItemsCount = this.basketService.ItemsCount()
            };

            return View(viewModel);
        }
    }
}
