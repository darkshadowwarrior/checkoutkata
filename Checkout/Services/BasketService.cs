using System.Collections.Generic;
using System.Linq;
using Checkout.Models;

namespace Checkout.Services
{
    public class BasketService
    {
        private readonly List<Item> _items;
        private double _total;
        private readonly List<OfferItem> _offers;

        public BasketService(DiscountService discountService)
        {
            _items = new List<Item>();
            _offers = discountService.GetOffers();
        }

        public void Scan(Item item)
        {
            _items.Add(item);
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            _total = _items.Where(item => IsInOffer(item.SKU) == false).Sum(item => item.UnitPrice);
        }

        private bool IsInOffer(string itemSku)
        {
            return _offers.Any(offer => offer.SKU == itemSku);
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
