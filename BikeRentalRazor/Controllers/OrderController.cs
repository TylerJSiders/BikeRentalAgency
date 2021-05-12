using BikeRentalLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalRazor.Models.ViewModels;
using BikeRentalRazor.Models;

namespace BikeRentalRazor.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBikeRentalRepo repository;
        private Cart cart;

        public OrderController(IBikeRentalRepo repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }
        public async Task<ViewResult> Checkout()
        {
            BikeListViewModel vm = new BikeListViewModel(await repository.GetRentalShops());
            return View(vm); 
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(BikeListViewModel BLVM)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            
            BLVM.Reservation.ReservationDate = DateTime.Now.Date;
            BLVM.Reservation.BikeQuantity = cart.Lines.Count();
            BLVM.Reservation.TotalPrice = cart.ComputeTotalValue();
            BLVM.Reservation.Bikes = cart.Bikes;
            BLVM.Reservation.Discount = 0;

            if (ModelState.IsValid)
            {
                await repository.AddCustomer(BLVM.Customer);
                var customers = await repository.GetCustomers();
                //var thiscustomer = customers.Where(c => c.Email == BLVM.Customer.Email);
                var thiscustomer = customers.OrderByDescending(c => c.ID).FirstOrDefault();
                BLVM.Reservation.CustomerID = thiscustomer.ID;
                await repository.AddReservation(BLVM.Reservation);
                cart.Clear();
                return RedirectToPage("/Completed", new { ID = BLVM.Reservation.ID });
            }
            else
            {
                return View(new BikeListViewModel(await repository.GetRentalShops()));
            }
        }


    }
}
