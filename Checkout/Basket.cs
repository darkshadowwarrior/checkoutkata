using System.Collections.Generic;
using System.Linq;
using Checkout.Models;

namespace Checkout
{
    public class Basket
    {
        private readonly List<Item> _items;

        public Basket()
        {
            _items = new List<Item>();
        }

        public void Scan(Item item)
        {
            _items.Add(item);
        }

        public int GetItemCount()
        {
            return _items.Count;
        }

        public double GetTotal()
        {
            return _items.Sum(o => o.UnitPrice);
        }
    }
}
