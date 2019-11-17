using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aptex.Contracts.ViewModels
{
    public class BasketSummaryViewModel
    {
        public BasketSummaryViewModel()
        {
            DeliveryOptions = new List<SelectListItem>();
            PaymentOptions = new List<SelectListItem>();
            Products = new List<ProductViewModel>();
        }

        [Required]
        public string CustomerFullName { get; set; }

        [EmailAddress]
        [Required]
        public string CustomerEmail { get; set; }

        [Required]
        public string AddrCity { get; set; }

        [Required]
        public string AddrCode { get; set; }

        [Required]
        public string AddrSt { get; set; }

        public List<SelectListItem> DeliveryOptions { get; set; }

        [Required]
        public int DeliveryOptionId { get; set; }

        public List<SelectListItem> PaymentOptions { get; set; }

        [Required]
        public int PaymentOptionId { get; set; }


        public List<ProductViewModel> Products { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
