using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aptex.Contracts.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Categories = new List<SelectListItem>();
        }

        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string ImageUrl { get; set; }

        public string ProductReception { get; set; }

        [Range(0.0, 999.0)]
        public decimal Price { get; set; }

        [Required]
        public string Quantity { get; set; }

        public int BasketItemsCount { get; set; }

        public List<SelectListItem> Categories { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        public bool OnPrescription { get; set; }
    }
}
