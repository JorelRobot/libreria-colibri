﻿using Microsoft.AspNetCore.Mvc;

namespace LibreriaColibri.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BookDetails()
        {
            return View();
        }
    }
}
