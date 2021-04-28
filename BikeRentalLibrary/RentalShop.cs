using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalLibrary
{
    public class RentalShop
    {
        public int ID { get; set; }
        [Required]
        public string ShopName { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddresLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
