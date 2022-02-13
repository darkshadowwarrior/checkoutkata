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
                new OfferItem(),
                new OfferItem()
            };
        }

        public List<OfferItem> GetOffers()
        {
            return _items;
        }
    }
}
