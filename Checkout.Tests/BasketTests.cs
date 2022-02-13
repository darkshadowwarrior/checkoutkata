using Checkout.Models;
using NUnit.Framework;

namespace Checkout.Tests
{
    public class BasketTests
    {
        [Test]
        public void GivenOneItemToScan_ItemCanBeAddedToBasketCart()
        {
            var basket = new Basket();

            basket.Scan(new Item {SKU = "A99", UnitPrice = 0.50});

            var itemCount = basket.GetItemCount();

            Assert.That(itemCount, Is.EqualTo(1));
        }
    }
}
