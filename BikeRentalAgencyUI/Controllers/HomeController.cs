using BikeRentalAgencyUI.Models;
using BikeRentalLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            AdminLogin admin = new AdminLogin();

            return View(admin);
        }
        [HttpPost]
        public ActionResult Index(AdminLogin admin)
        {
            if (admin.Username != "Admin123" && admin.Password != "Secret!@#")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "LoggedIn");
            }
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
