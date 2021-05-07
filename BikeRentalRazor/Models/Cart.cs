using BikeRentalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalRazor.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Bike bike, int quantity)
        {
            CartLine line = Lines
            .Where(p => p.Bike.ID == bike.ID)
            .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Bike = bike,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Bike bike) =>
        Lines.RemoveAll(l => l.Bike.ID == bike.ID);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.Bike.UnitPrice * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Bike Bike { get; set; }
        public int Quantity { get; set; }
    }
}

