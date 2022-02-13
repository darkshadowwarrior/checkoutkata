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

        [Test]
        public void GivenTwoItemToScan_ItemsCanBeAddedToBasketCart_ReturnsBasketTotalAs_80()
        {
            var basket = new Basket();

            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });

            var itemCount = basket.GetTotal();

            Assert.That(itemCount, Is.EqualTo(0.80));
        }
    }
}
