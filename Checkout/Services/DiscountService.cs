using System.Collections.Generic;
using Checkout.Models;

namespace Checkout.Services
{
    public class DiscountService
    {
        private readonly List<OfferItem> _items;

        public DiscountService()
        {
            _items = new List<OfferItem>()
            {
                new OfferItem() { SKU = "B15", Quantity = 2, OfferPrice = 0.45},
                new OfferItem() { SKU = "A99", Quantity = 3, OfferPrice = 1.30}
            };
        }

        public List<OfferItem> GetOffers()
        {
            return _items;
        }
    }
}
