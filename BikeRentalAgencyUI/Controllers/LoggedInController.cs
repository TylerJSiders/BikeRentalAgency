using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Controllers
{
    public class LoggedInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
