using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWishlistTracker.WishlistScreenScraper.Dto
{
    public class ScrapedBook
    {
       public string Id { get; private set; }
       public string WishlistId { get; private set; }

       public string Title { get; private set; }
       public decimal? AwPrice { get; private set; }

        public ScrapedBook(string id, string wishlistId, string title, decimal? price)
        {
            if(id == null)
                throw new ArgumentNullException();
            if(wishlistId == null)
                throw new ArgumentNullException();
            if(title == null)
                throw new ArgumentNullException();

            Id = id;
            WishlistId = wishlistId;
            Title = title;
            AwPrice = price;
        }
    }
}
