﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;

namespace Aptex.Services
{
    public class ProductsService : IProductsService
    {
        public ProductsService()
        {

        }

        public List<Product> List()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Rutinoscorbin",
                    Reception = "Take two pills every 2 hours.",
                    Price = 10.30M,
                    Quantity = "30szt."
                },
                new Product
                {
                    Name = "Marsjanki",
                    Reception = "Don't take them at all",
                    Price = 20.30M,
                    Quantity = "50szt."
                }
            };
        }

        public List<Product> ListByCategories(List<int> categoryIds)
        {
            return new List<Product>();
        }
    }
}
