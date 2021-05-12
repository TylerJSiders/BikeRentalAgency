using BikeRentalAgencyUI.Models;
using BikeRentalAgencyUI.Models.Interfaces;
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
        private readonly IBikeRentalRepo _repo;

        public HomeController(ILogger<HomeController> logger, IBikeRentalRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            AdminLogin admin = new AdminLogin();

            return View(admin);
        }
        [HttpPost]
        public async Task<ActionResult> Index(AdminLogin admin)
        {
            var admins = await _repo.GetAdmins();
            var adminlogin = admins.Where(a => a.Username == admin.Username && a.Password == admin.Password).FirstOrDefault();
            if (adminlogin == null)
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
