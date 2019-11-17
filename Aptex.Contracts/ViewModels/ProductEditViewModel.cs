using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aptex.Contracts.ViewModels
{
    public class ProductEditViewModel
    {
        public ProductEditViewModel()
        {
            Products = new List<SelectListItem>();
        }
        
        public List<SelectListItem> Products { get; set; }

        public int SelectedProductId { get; set; }

        public ProductViewModel SelectedProduct { get; set; }
    }
}
