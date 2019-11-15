﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Aptex.Web.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View("Basket");
        }

        [HttpPost]
        public IActionResult Index(BasketSummaryViewModel viewModel)
        {
            return View("Success");
        }
    }
}