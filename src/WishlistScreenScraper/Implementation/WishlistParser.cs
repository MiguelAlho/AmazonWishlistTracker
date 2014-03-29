using System;
using System.Collections.Generic;
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
    }
}
