using AmazonWishlistTracker.WishlistScreenScraper.Dto;
using System;
using System.Text.RegularExpressions;

namespace AmazonWishlistTracker.WishlistScreenScraper.Interfaces
{
    public interface IWishlistParsingDefinitions
    {
        string OfferListingQuoteSplitString { get; }
        string OfferListingInternationalOffer { get; }


        Uri WishlistCollectionUri { get; }
        Uri BookListUriForWishlistAtPage(string wishlistId, int page);
        Uri OfferListingUriForBookAtPage(string bookId, int page);

        Regex WishlistCollectionRegex { get; }
        Regex BookListItemRegex { get; }
        Regex BookListPageCountRegex { get; }

        Func<Match, Wishlist> WishlistMatchMapperFunc { get; }
        Func<Match, ScrapedBook> ScrapedBookMatchMapperFunc { get; }
        Func<string, Quote> OfferToQuoteMapperFunc { get; }
    
    }
}