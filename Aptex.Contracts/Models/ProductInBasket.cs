using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aptex.Contracts.Models
{
    public class ProductInBasket : Entity
    {
        public int ProductId { get; set; }

        public string UserId { get; set; }

        public int Count { get; set; }
    }
}
