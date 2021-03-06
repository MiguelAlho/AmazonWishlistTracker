﻿using AmazonWishlistTracker.WishlistScreenScraper.Dto;
using System.Collections.Generic;

namespace AmazonWishlistTracker.WishlistScreenScraper.Interfaces
{
    public interface IWishlistParser
    {
        IList<Wishlist> GetWishlistsForUser(string userEmail);
        IList<ScrapedBook> GetBookListForWishlist(string wishlistId);
        Quote GetBestInternationlOfferFor(string bookId);
    }
}
