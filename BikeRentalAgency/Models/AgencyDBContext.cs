using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BikeRentalLibrary;

namespace BikeRentalAgency.Models
{
    public class AgencyDBContext : DbContext
    {
        public AgencyDBContext(DbContextOptions<AgencyDBContext> options) : base(options)
        {

        }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RentalShop> Shops { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        //public DbSet<ReservationDetails> ReservationDetails { get; set; }
        public DbSet<SpecialFeature> SpecialFeatures { get; set; }
    }
}
