using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalLibrary;
namespace BikeRentalRazor.Models.ViewModels
{
    public class BikeListViewModel
    {
        public IEnumerable<Bike> Bikes { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public List<RentalShop> Shops { get; set; }
    }
}
