using System.Collections.Generic;
using System.Linq;
using Checkout.Interfaces;
using Checkout.Models;

namespace Checkout.Services
{
    public class BasketService : IBasketService
    {
        private readonly List<Item> _items;
        private double _total;
        private readonly List<OfferItem> _offers;

        public BasketService(IDiscountService discountService)
        {
            _items = new List<Item>();
            _offers = discountService.GetOffers();
        }

        public void Scan(Item item)
        {
            _items.Add(item);
            UpdateTotal();
        }

        public int GetItemCount()
        {
            return _items.Count;
        }

        public double GetTotal()
        {
            return _total;
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

        private void CalculateDiscountedItems()
        {
            _offers.ForEach(offer =>
            {
                var item = _items.FirstOrDefault(item => item.SKU == offer.SKU);
                if (item != null)
                {
                    var countOfItemsInOffer = _items.Count(o => o.SKU == offer.SKU);

                    _total += Calculate(countOfItemsInOffer, offer, item.UnitPrice);
                }
            });
        }

        private double Calculate(int countOfItemsInOffer, OfferItem offer, double itemUnitPrice)
        {
            var totalDiscounts = countOfItemsInOffer / offer.Quantity;

            var calculatedCost = (countOfItemsInOffer % offer.Quantity == 0) ? totalDiscounts * offer.OfferPrice : totalDiscounts * offer.OfferPrice + itemUnitPrice;

            return calculatedCost;
        }
    }
}
