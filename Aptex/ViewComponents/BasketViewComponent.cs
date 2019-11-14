using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Interfaces;
using Aptex.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Aptex.ViewComponents
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
