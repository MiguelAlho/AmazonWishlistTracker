using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AmazonWishlistTracker.WishlistScreenScraper.Interfaces;
using AmazonWishlistTracker.WishlistScreenScraper.Infrastructure;
using AmazonWishlistTracker.WishlistScreenScraper.Dto;

namespace AmazonWishlistTracker.WishlistScreenScraper.Implementation
{
    public class WishlistParser : IWishlistParser
    {
        private IWishlistParsingDefinitions definitions;
        private IWebClient webClient;

        /// <summary>
        /// Create a wishlist parser
        /// </summary>
        /// <param name="definitions">parsing definitions</param>
        /// <param name="webClient">web acess library</param>
        public WishlistParser(IWishlistParsingDefinitions definitions, IWebClient webClient)
        {
            if(definitions == null)
                throw new ArgumentNullException("definitions", "argument must be non null");
            if (webClient == null)
                throw new ArgumentNullException("webClient", "argument must be non null");

            this.definitions = definitions;
            this.webClient = webClient;
        }

        /// <summary>
        /// Get the list of wishlists for the specified user
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public IList<Wishlist> GetWishlistsForUser(string userEmail)
        {
            var uri = definitions.WishlistCollectionUri;
            var html = GetHtmlFromUri(uri);
            return GetWishlistsFromhtml(html);
        }

        private IList<Wishlist> GetWishlistsFromhtml(string html)
        {
            IList<Wishlist> wishlists = new List<Wishlist>();
            
            Regex regexObj = definitions.WishlistCollectionRegex;
            Match matchResult = regexObj.Match(html);
            while (matchResult.Success)
            {
                wishlists.Add(definitions.WishlistMatchMapperFunc(matchResult));
                matchResult = matchResult.NextMatch();
            }

            return wishlists;
        }

        private string GetHtmlFromUri(Uri uri)
        {
            byte[] byteData = webClient.DownloadData(uri);
            string html = Encoding.UTF8.GetString(byteData);
            return html;
        }


        public IList<ScrapedBook> GetBookListForWishlist(string wishlistId)
        {
            //first URI available for the wishlist. Use it to determine if more pages for the list exist
            var baseuri = definitions.BookListUriForWishlistAtPage(wishlistId, 1);
            var html = GetHtmlFromUri(baseuri);

            int pages = GetNumberOfPagesForWishlist(html);
            
            IList<ScrapedBook> books = new List<ScrapedBook>();
            GetBooksFromHtml(html, wishlistId).ForEach(o => books.Add(o));

            if (pages > 1)
            {
                for (int i = 2; i <= pages; i++)
                {
                    var pageUri = definitions.BookListUriForWishlistAtPage(wishlistId, i);
                    var pagehtml = GetHtmlFromUri(pageUri);
                    GetBooksFromHtml(pagehtml, wishlistId).ForEach(o => books.Add(o));
                }
            }

            return books;
        }

        
        private List<ScrapedBook> GetBooksFromHtml(string html, string wishlistId)
        {
            List<ScrapedBook> books = new List<ScrapedBook>();

            Regex regexObj = definitions.BookListItemRegex;
            Match matchResult = regexObj.Match(html);
            while (matchResult.Success)
            {
                books.Add(definitions.ScrapedBookMatchMapperFunc(matchResult));
                matchResult = matchResult.NextMatch();
            }

            return books;
        }

        private int GetNumberOfPagesForWishlist(string html)
        {
            //we'll search the base page for the "nextPage" links. The number of links next set of pages + "next" page
            //will give us a total of pages available.
            //TODO: consider single page witshlists!

            Regex regexObj = definitions.BookListPageCountRegex;
            Match matchResult = regexObj.Match(html);

            var counter = 0;
            while (matchResult.Success)
            {
                counter++;
                matchResult = matchResult.NextMatch();
            }

            return counter;
        }
    }
}
