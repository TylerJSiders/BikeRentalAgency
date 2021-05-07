//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BikeRentalLibrary
//{
//    [Keyless]
//    public class ReservationDetails
//    {
//        public int ReservationID { get; set; }
//        [Required]
//        public DateTime ReservationDate { get; set; }
//        [Required]
//        public decimal TotalPrice { get; set; }
//        [Required]
//        public int BikeQuantity { get; set; }
//        [Required]
//        public decimal Discount { get; set; }
//        public List<SpecialFeature> SpecialFeatures { get; set; } = new List<SpecialFeature>();
//        [Required]
//        public string PaymentType { get; set; }
//    }
//}
