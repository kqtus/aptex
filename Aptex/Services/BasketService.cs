﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Interfaces;

namespace Aptex.Services
{
    public class BasketService : IBasketService
    {
        public int ItemsCount()
        {
            return 10;
        }
    }
}