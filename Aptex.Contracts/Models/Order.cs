using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aptex.Contracts.Models
{
    public class Order : Entity
    {
        public List<ProductInOrder> ProductsInOrder { get; set; }
    }
}
