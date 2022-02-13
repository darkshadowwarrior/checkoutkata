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
            CalculateDiscountedItems();
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
            return _total;
        }

        private void CalculateDiscountedItems()
        {
            _offers.ForEach(offer =>
            {
                var item = _items.FirstOrDefault(item => item.SKU == offer.SKU);
                if (item != null)
                {
                    var count = _items.Count(o => o.SKU == offer.SKU);

                    _total += Calculate(count, offer, item.UnitPrice);
                }
            });
        }

        private double Calculate(int count, OfferItem offer, double itemUnitPrice)
        {
            var discountCount = count / offer.Quantity;

            var calculatedCost = (count % offer.Quantity == 0) ? discountCount * offer.OfferPrice : discountCount * offer.OfferPrice + itemUnitPrice;

            return calculatedCost;
        }
    }
}
