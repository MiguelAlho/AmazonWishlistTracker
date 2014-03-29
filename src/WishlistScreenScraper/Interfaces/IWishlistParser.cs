using AmazonWishlistTracker.WishlistScreenScraper.Dto;
using System.Collections.Generic;

namespace AmazonWishlistTracker.WishlistScreenScraper.Interfaces
{
    public interface IWishlistParser
    {
        IList<Wishlist> GetWishlistsForUser(string userEmail);
      
    }
}
