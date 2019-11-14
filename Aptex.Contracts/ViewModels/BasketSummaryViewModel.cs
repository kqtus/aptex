using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aptex.ViewModels
{
    public class BasketSummaryViewModel
    {
        public string CustomerFullName { get; set; }

        public string CustomerEmail { get; set; }

        public string AddrCity { get; set; }

        public string AddrCode { get; set; }

        public string AddrSt { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
