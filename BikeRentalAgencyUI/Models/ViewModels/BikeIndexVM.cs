using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalLibrary;

namespace BikeRentalAgencyUI.Models.ViewModels
{
    public class BikeIndexVM
    {
        public List<Bike> Bikes;
        public List<RentalShop> RentalShops;

        public BikeIndexVM(List<Bike> Bikes, List<RentalShop> RentalShops)
        {
            this.Bikes = Bikes;
            this.RentalShops = RentalShops;
        }
    }
}
