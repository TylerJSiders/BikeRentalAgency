using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalLibrary;
using BikeRentalRazor.Infrastructure;
using BikeRentalRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeRentalRazor.Pages
{
    public class CartModel : PageModel
    {
        private IBikeRentalRepo repository;
        public CartModel(IBikeRentalRepo repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public async Task<IActionResult> OnPost(int bikeId, string returnUrl)
        {
            Bike bike = await repository.GetBikeByID(bikeId);
           // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(bike, 1);
           // HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bikeId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Bike.ID == bikeId).Bike);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
