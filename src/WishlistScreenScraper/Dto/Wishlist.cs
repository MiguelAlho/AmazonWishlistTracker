using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWishlistTracker.WishlistScreenScraper.Dto
{
    public class Wishlist
    {
        public object Name { get; private set; }
        public object AwId { get; private set; }
        public object BookCount { get; private set; }

        public Wishlist(string name, string amazonId, int bookCount)
        {
            Name = name;
            AwId = amazonId;
            BookCount = bookCount;
        }
    }
}
