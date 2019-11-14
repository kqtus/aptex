using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aptex.Contracts.ViewModels
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }

        public string ProductReception { get; set; }

        public decimal Price { get; set; }

        public string Quantity { get; set; }
    }
}
