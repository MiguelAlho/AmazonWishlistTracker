using AmazonWishlistTracker.WishlistScreenScraper.Implementation.Definitions;
using AmazonWishlistTracker.WishlistScreenScraper.Interfaces;

namespace AmazonWishlistTracker.WishlistScreenScraper.Implementation
{
    public class WishlistParsingDefinitionsFactory
    {

        public static IWishlistParsingDefinitions GetDefinitionsFor(WishlistScraperConfiguration wishlistScraperConfiguration)
        {
            return new AmazonUKParsingDefinitions();
        }
    }
}