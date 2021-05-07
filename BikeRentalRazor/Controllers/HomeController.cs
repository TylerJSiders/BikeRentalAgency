using Microsoft.AspNetCore.Mvc;
using BikeRentalRazor.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using BikeRentalLibrary;
using System.Linq;
using BikeRentalRazor.Models.ViewModels;

namespace BikeRentalRazor.Controllers
{
    public class HomeController : Controller
    {
        private IBikeRentalRepo repository;
        public int pageSize = 3;
        public HomeController(IBikeRentalRepo repo)
        {
            repository = repo;
        }
        public async Task<ActionResult> Index( int? currentStoreID, int productPage = 0)
        {
            List<Bike> bikes = await repository.GetBikes();
            if (bikes == null)
                bikes = new List<Bike>();
            var bikeToView = bikes.Where(b => currentStoreID == null || b.CurrentLocationID == currentStoreID).OrderBy(b => b.ID).Skip((productPage - 1) * pageSize).Take(pageSize);
            //Setup Paging info
            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = productPage;
            pagingInfo.ItemsPerPage = pageSize;
            pagingInfo.TotalItems = bikes.Count;

            BikeListViewModel bikeListViewModel = new();
            bikeListViewModel.Bikes = bikeToView;
            bikeListViewModel.PagingInfo = pagingInfo;
            bikeListViewModel.Shops = await repository.GetRentalShops();

            return View(bikeListViewModel);
        }
    }
}
