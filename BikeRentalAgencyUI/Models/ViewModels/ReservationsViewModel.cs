using BikeRentalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BikeRentalAgencyUI.Models.ViewModels
{
    public class ReservationsViewModel
    {
        List<Reservation> reservations { get; set; }
        List<ReservationDetails> resDetails { get; set; }
    }
}
