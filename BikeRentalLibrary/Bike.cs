using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace BikeRentalLibrary
{
    public class Bike
    {
        public int ID { get; set; }
        [Required]
        public string BikeName { get; set; }
        [Required]
        public int CurrentLocationID { get; set; }
        [Required]
        public bool isReserved { get; set; }
        [Required]
        public string FrameSize { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
    }
}
