using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWishlistTracker.WishlistScreenScraper.Dto
{
    public class Quote
    {
        public string BookId { get; private set; }
        public string SellerId { get; private set; }

        public string SellerName { get; private set; }
        public decimal Price { get; private set; }
        public string Condition { get; private set; }

        public Quote(string bookId, string sellerId, string sellerName, decimal price, string condition)
        {
            if(bookId == null)
                throw new ArgumentNullException();
            if(sellerId == null)
                throw new ArgumentNullException();
            if(sellerName == null)
                throw new ArgumentNullException();
            if (condition == null)
                throw new ArgumentNullException();

            BookId = bookId;
            SellerId = sellerId;
            SellerName = sellerName;
            Price = price;
            Condition = condition;
        }
    }
}
