using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BikeRentalLibrary;
using BikeRentalRazor.Models;

namespace BikeRentalRazor.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IBikeRentalRepo Repository;

        public NavigationMenuViewComponent(IBikeRentalRepo repo)
        {
            Repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            var RentalShops = Repository.GetRentalShops();
            return View(RentalShops);
        }
    }
}
