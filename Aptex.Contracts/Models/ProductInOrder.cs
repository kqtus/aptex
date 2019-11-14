﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aptex.Contracts.Models
{
    public class ProductInOrder : Entity
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int Count { get; set; }
    }
}