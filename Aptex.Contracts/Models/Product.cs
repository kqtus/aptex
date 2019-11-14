using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aptex.Contracts.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public string Reception { get; set; }

        public decimal Price { get; set; }

        public string Quantity { get; set; }
    }
}
