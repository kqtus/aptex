using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aptex.ViewModels;

namespace Aptex.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ProductViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
