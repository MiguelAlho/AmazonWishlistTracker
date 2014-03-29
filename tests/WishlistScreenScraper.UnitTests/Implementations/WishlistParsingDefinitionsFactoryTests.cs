using AmazonWishlistTracker.WishlistScreenScraper.Implementation;
using AmazonWishlistTracker.WishlistScreenScraper.Implementation.Definitions;
using AmazonWishlistTracker.WishlistScreenScraper.Interfaces;
using NUnit.Framework;

namespace WishlistScreenScraper.UnitTests.Implementations
{
    [TestFixture]
    public class WishlistParsingDefinitionsFactoryTests
    {
        [Test]
        public void CanGetDefinitionsForAmazonUK()
        {
            IWishlistParsingDefinitions definitions = WishlistParsingDefinitionsFactory.GetDefinitionsFor(
                new WishlistScraperConfiguration()
                {
                    AmazonTarget = AmazonTargets.UK,
                    Email = "user@domain.com"
                }
            );

            Assert.IsNotNull(definitions);
            Assert.IsInstanceOf<IWishlistParsingDefinitions>(definitions);
            Assert.IsInstanceOf<AmazonUKParsingDefinitions>(definitions);
        }
    }
}