﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Aptex.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View("Basket");
        }
    }
}