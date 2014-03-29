using AmazonWishlistTracker.WishlistScreenScraper.Implementation;
using NUnit.Framework;
namespace WishlistScreenScraper.UnitTests.Implementations
{
    [TestFixture]
    public class WishlistScraperConfigurationTests
    {
        [Test]
        public void CanCreateInstanceOfWishlistScraperConfigurationTests()
        {
            var instance = new WishlistScraperConfiguration();
            Assert.IsNotNull(instance);
        }

        
    }
}