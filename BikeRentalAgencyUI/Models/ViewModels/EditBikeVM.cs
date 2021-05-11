using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalLibrary;

namespace BikeRentalAgencyUI.Models.ViewModels
{
    public class EditBikeVM
    {
        public Bike bike;
        public List<RentalShop> rentalShops;

        public EditBikeVM()
        {

        }


        public EditBikeVM(Bike bike, List<RentalShop> rentalShops)
        {
            this.bike = bike;
            this.rentalShops = rentalShops;
        }
    }
}
