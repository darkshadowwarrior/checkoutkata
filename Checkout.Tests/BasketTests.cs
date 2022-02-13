using Checkout.Models;
using Checkout.Services;
using NUnit.Framework;

namespace Checkout.Tests
{
    public class BasketTests
    {
        [Test]
        public void GivenOneItemToScan_ItemCanBeAddedToBasketCart()
        {
            var basket = new BasketService(new DiscountService());

            basket.Scan(new Item {SKU = "A99", UnitPrice = 0.50});

            var itemCount = basket.GetItemCount();

            Assert.That(itemCount, Is.EqualTo(1));
        }

        [Test]
        public void GivenThreeItemSToScan_ItemsCanBeAddedToBasketCart_ReturnsBasketTotalAs_()
        {
            var basket = new BasketService(new DiscountService());

            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });
            basket.Scan(new Item { SKU = "C40", UnitPrice = 0.60 });

            var basketTotal = basket.GetTotal();

            Assert.That(basketTotal, Is.EqualTo(1.40));
        }

        [Test]
        public void GivenTwoItemToScan_ItemsCanBeAddedToBasketCart_ReturnsBasketTotalAs_80()
        {
            var basket = new BasketService(new DiscountService());

            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });

            var basketTotal = basket.GetTotal();

            Assert.That(basketTotal, Is.EqualTo(0.80));
        }

        [Test]
        public void GivenTwoOfTheSameItemToScan_ItemsCanBeAddedToBasketCart_DiscountIdApplied_ReturnsBasketTotalAs_45()
        {
            var basket = new BasketService(new DiscountService());

            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });
            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });

            var basketTotal = basket.GetTotal();

            Assert.That(basketTotal, Is.EqualTo(0.45));
        }

        [Test]
        public void GivenThreeOfTheSameItemToScan_ItemsCanBeAddedToBasketCart_DiscountIdApplied_ReturnsBasketTotalAs_130()
        {
            var basket = new BasketService(new DiscountService());

            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });

            var basketTotal = basket.GetTotal();

            Assert.That(basketTotal, Is.EqualTo(1.30));
        }

        [Test]
        public void GivenASetOfTheItemsToScanInARandomOrder_ItemsCanBeAddedToBasketCart_DiscountIdApplied_ReturnsBasketTotalAs_235()
        {
            var basket = new BasketService(new DiscountService());

            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "C40", UnitPrice = 0.60 });

            var basketTotal = basket.GetTotal();

            Assert.That(basketTotal, Is.EqualTo(2.35));
        }

        [Test]
        public void GivenASetOfTheItemsToScanInARandomOrder_ItemsCanBeAddedToBasketCart_DiscountIdApplied_ReturnsBasketTotalAs_470()
        {
            var basket = new BasketService(new DiscountService());

            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "C40", UnitPrice = 0.60 });

            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "C40", UnitPrice = 0.60 });

            var basketTotal = basket.GetTotal();

            Assert.That(basketTotal, Is.EqualTo(4.70));
        }

        [Test]
        public void GivenASetOfTheItemsToScanInARandomOrder_ItemsCanBeAddedToBasketCart_DiscountIdApplied_ReturnsBasketTotalAs_445()
        {
            var basket = new BasketService(new DiscountService());

            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "C40", UnitPrice = 0.60 });

            basket.Scan(new Item { SKU = "B15", UnitPrice = 0.30 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "A99", UnitPrice = 0.50 });
            basket.Scan(new Item { SKU = "C40", UnitPrice = 0.60 });

            var basketTotal = basket.GetTotal();

            Assert.That(basketTotal, Is.EqualTo(4.55));
        }
    }
}
