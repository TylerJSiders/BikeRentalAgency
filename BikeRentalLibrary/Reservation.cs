using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalLibrary
{
    public class Reservation
    {
        public int ID { get; set; }
        [Required]
        public List<Bike> Bikes { get; set; } = new List<Bike>();
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public DateTime PickupDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public int LocationStart { get; set; }
        [Required]
        public int LocationEnd { get; set; }
    }
}
