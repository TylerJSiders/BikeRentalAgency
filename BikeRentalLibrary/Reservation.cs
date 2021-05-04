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
        [Required]
        public DateTime ReservationDate { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public int BikeQuantity { get; set; }
        [Required]
        public decimal Discount { get; set; }
        public List<SpecialFeature> SpecialFeatures { get; set; } = new List<SpecialFeature>();
        [Required]
        public string PaymentType { get; set; }
    }
}
