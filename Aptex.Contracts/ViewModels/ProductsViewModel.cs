using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aptex.Contracts.ViewModels
{
    public class ProductsViewModel
    {
        public ProductsViewModel()
        {
            Categories = new List<CategorySelectViewModel>();
            Products = new List<ProductViewModel>();
        }

        public List<CategorySelectViewModel> Categories { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
