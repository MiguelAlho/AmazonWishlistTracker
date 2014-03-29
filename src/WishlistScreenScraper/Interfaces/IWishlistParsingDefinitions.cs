using AmazonWishlistTracker.WishlistScreenScraper.Dto;
using System;
using System.Text.RegularExpressions;

namespace AmazonWishlistTracker.WishlistScreenScraper.Interfaces
{
    public interface IWishlistParsingDefinitions
    {
        Uri WishlistCollectionUri { get; }

        Regex WishlistCollectionRegex { get; }
        Func<Match, Wishlist> WishlistMatchMapperFunc { get; }

    }
}