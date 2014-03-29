using AmazonWishlistTracker.WishlistScreenScraper.Dto;
using System;
using System.Text.RegularExpressions;

namespace AmazonWishlistTracker.WishlistScreenScraper.Interfaces
{
    public interface IWishlistParsingDefinitions
    {
        Uri WishlistCollectionUri { get; }
        Uri BookListUriForWishlistAtPage(string wishlistId, int page);

        Regex WishlistCollectionRegex { get; }
        Regex BookListItemRegex { get; }
        Regex BookListPageCountRegex { get; }

        Func<Match, Wishlist> WishlistMatchMapperFunc { get; }
        Func<Match, ScrapedBook> ScrapedBookMatchMapperFunc { get; }


    }
}