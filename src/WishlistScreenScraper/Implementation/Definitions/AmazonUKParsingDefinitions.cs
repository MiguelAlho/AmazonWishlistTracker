using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using AmazonWishlistTracker.WishlistScreenScraper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonWishlistTracker.WishlistScreenScraper.Dto;
using System.Globalization;

namespace AmazonWishlistTracker.WishlistScreenScraper.Implementation.Definitions
{
    /// <summary>
    /// Class contains the definitions for Amazon.co.uk
    /// </summary>
    public class AmazonUKParsingDefinitions : IWishlistParsingDefinitions
    {
        #region regexes
        //<a href="/gp/aw/ls/ref=aw_ls\?lid=(?'amazonId'[A-Z0-9]*)">(?:<b><font color='#[A-F0-9]{6}'>)?(?'wishlistname'[\w\s]*)(?:</font></b>)?</a>
        private readonly Regex wishlistRegex = new Regex(
                @"<a href=""/gp/aw/ls/ref=aw_ls\?lid=(?'amazonId'[A-Z0-9]*)"">(?:<b><font color='#[A-F0-9]{6}'>)?(?'wishlistname'[\w\s]*)(?:</font></b>)?</a>
 <span>
 <font color=""gray"">
 &nbsp;\((?'bookCount'\d*)\)&nbsp;");

        private const string wishklistRegex_name = "wishlistname";
        private const string wishklistRegex_awid = "amazonId";
        private const string wishklistRegex_bookCount = "bookCount";

        ///book regex ref: respect paragraph entries
        /*
         * <a href="/gp/aw/d/(?'bookId'[\w]*)/ref=aw_ls_(?:\d*)_(?:\d*)\?colid=(?:[A-Z0-9]*)&coliid=(?:[A-Z0-9]*)">(?'title'[\w\s()-:#.',\[\]]*)</a>
<br />
(?: (?:£?)(?'price'[\d\.]*)?)?
*/
        private readonly Regex bookListRegex = new Regex(@"<a href=""/gp/aw/d/(?'bookId'[\w]*)/ref=aw_ls_(?:\d*)_(?:\d*)\?colid=(?'wishlistId'[A-Z0-9]*)&coliid=(?:[A-Z0-9]*)"">(?'title'[\w\s()-:#.',[\]]*)</a>
 <br />
(?: (?:£?)(?'price'[\d.]*)?)?
");
        private const string booklistRegex_id = "bookId";
        private const string booklistRegex_title = "title";
        private const string booklistRegex_price = "price";
        private const string booklistRegex_wishlistId = "wishlistId";

        private readonly Regex bookListPageCountRegex = new Regex(@"<a href=""/gp/aw/ls/ref=aw_ls_(?:\d*)\?lid=(?:[A-Z0-9]*)&p=(?:[0-9]*)&reveal=unpurchased&sort=date-added&ty=wishlist"">(?'page'\d*|Next)</a>");
            
        #endregion


        public const string WishlistCollectionUrlString = @"http://www.amazon.co.uk/gp/aw/ls";
        public const string BookListUrlFormatString = @"http://www.amazon.co.uk/gp/aw/ls/ref=aw_ls_{1}?lid={0}&p={1}&reveal=unpurchased&sort=date-added&ty=wishlist";
        public const string OfferListingFormatString = @"http://www.amazon.co.uk/gp/offer-listing/{0}/sr=/qid=/ref=olp_page_{1}?ie=UTF8&colid=&coliid=&condition=all&me=&qid=&shipPromoFilter=0&sort=sip&sr=&startIndex={2}";

        
        public Uri WishlistCollectionUri
        {
            get { return new Uri(WishlistCollectionUrlString); }
        }

        public Regex WishlistCollectionRegex
        {
            get { return wishlistRegex; }
        }

        public Func<Match, Wishlist> WishlistMatchMapperFunc
        {
            get
            {
                return new Func<Match, Wishlist>(Match => 
                    new Wishlist(
                        Match.Groups[wishklistRegex_name].Value, 
                        Match.Groups[wishklistRegex_awid].Value,
                        int.Parse(Match.Groups[wishklistRegex_bookCount].Value)));
            }
        }


        public Uri BookListUriForWishlistAtPage(string wishlistId, int page)
        {
            return new Uri(String.Format(BookListUrlFormatString,wishlistId,page));
        }

        public Regex BookListItemRegex
        {
            get { return bookListRegex; }
        }

        public Regex BookListPageCountRegex
        {
            get { return bookListPageCountRegex; }
        }
        
        
        public Func<Match, ScrapedBook> ScrapedBookMatchMapperFunc
        {
            get
            {
                //price may not exist due to out of stock conditions for Amazon
                return new Func<Match, ScrapedBook>(Match =>
                {
                    decimal? price = Match.Groups[booklistRegex_price].Success
                        ? decimal.Parse(Match.Groups[booklistRegex_price].Value, 
                                        NumberStyles.AllowDecimalPoint, 
                                        CultureInfo.InvariantCulture)
                        : null as decimal?;

                    return new ScrapedBook(
                        Match.Groups[booklistRegex_id].Value.Trim(),
                        Match.Groups[booklistRegex_wishlistId].Value.Trim(),
                        Match.Groups[booklistRegex_title].Value.Trim(), 
                        price);
                });
            }
        }


        public Uri OfferListingUriForBookAtPage(string bookId, int page)
        {
            return new Uri(String.Format(OfferListingFormatString, bookId, page, (page-1)*10));
        }

        public string OfferListingQuoteSplitString
        {
            get { return @"<span class=""a-size-large a-color-price olpOfferPrice a-text-bold"">"; }
        }
        
        public string OfferListingInternationalOffer
        {
            get { return "International & domestic delivery rates"; }
        }

        public Func<string, Quote> OfferToQuoteMapperFunc
        {
            get
            {
                //price may not exist due to out of stock conditions for Amazon
                return new Func<string, Quote>(textBlock =>
                {
                    var priceText = new Regex(@"£(?'price'[\d.]*)").Match(textBlock).Groups["price"].Value.Trim();
                    decimal price = decimal.Parse(priceText, NumberStyles.AllowDecimalPoint,
                        CultureInfo.InvariantCulture);

                    var condition = new Regex(@"olpCondition"">(?'condition'[\w\s]*)</h3>").Match(textBlock).Groups["condition"].Value.Trim();
                    
                    Regex sellerRegex = new Regex(@"<a href=""/gp/aag/main/ref=olp_merch_name_(?:\d*)\?ie=UTF8&amp;asin=(?'bookId'[\w]*)&amp;isAmazonFulfilled=(?:\d)&amp;seller=(?'sellerId'[\w]*)"">(?'sellerName'[\w\s-_]*)</a>");
                    Match match = sellerRegex.Match(textBlock);
                    var sellerId = match.Groups["sellerId"].Value.Trim();
                    var sellerName = match.Groups["sellerName"].Value.Trim();
                    var bookId = match.Groups["bookId"].Value.Trim();

                    Quote quote = new Quote(bookId, sellerId, sellerName, price, condition);

                    return quote;

                });
            }
        }
    }
}
