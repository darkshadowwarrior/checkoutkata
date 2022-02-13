using Checkout.Services;
using NUnit.Framework;

namespace Checkout.Tests
{
    public class DiscountServiceTests
    {
        [Test]
        public void GivenARequestForSpecialOffers_ReturnsListOfSpecialOffers()
        {
            var discountService = new DiscountService();

            var offers = discountService.GetOffers();

            Assert.That(offers.Count, Is.EqualTo(2));

        }
    }
}
