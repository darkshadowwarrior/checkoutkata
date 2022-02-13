using System.Collections.Generic;
using Checkout.Models;

namespace Checkout.Interfaces
{
    public interface IDiscountService
    {
        List<OfferItem> GetOffers();
    }
}