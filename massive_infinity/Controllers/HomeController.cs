using massive_infinity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using massive_infinity.Data;
using massive_infinity.Data.Entities;

namespace massive_infinity.Controllers
{
    public class HomeController : Controller
    {
        private readonly massive_infinityContext _context;
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger, massive_infinityContext context)
        {
            this._context = context;
            this._logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
