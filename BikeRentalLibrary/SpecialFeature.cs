using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalLibrary
{
    public class SpecialFeature
    {
        public int ID { get; set; }
        [Required]
        public string Feature { get; set; }
    }
}
