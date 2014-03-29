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

        public WishlistParser(IWishlistParsingDefinitions definitions, IWebClient webClient)
        {
            if(definitions == null)
                throw new ArgumentNullException("definitions", "argument must be non null");
            if (webClient == null)
                throw new ArgumentNullException("webClient", "argument must be non null");

            this.definitions = definitions;
            this.webClient = webClient;
        }


        public IList<Wishlist> GetWishlistsForUser(string userEmail)
        {
            IList<Wishlist> wishlists = new List<Wishlist>();

            var uri = new Uri(@"http://www.amazon.co.uk/gp/aw/ls"); //definitions.BaseUrl, definitions.WishlistRelativeUrlPath);
            byte[] byteData = webClient.DownloadData(uri);

            string html = Encoding.UTF8.GetString(byteData);

            //parse
            //raw regex:
            //<a href="/gp/aw/ls/ref=aw_ls\?lid=(?'amazonId'[A-Z0-9]*)">(?:<b><font color='#[A-F0-9]{6}'>)?(?'wishlistname'[\w\s]*)(?:</font></b>)?</a>
            Regex regexObj = new Regex(@"<a href=""/gp/aw/ls/ref=aw_ls\?lid=(?'amazonId'[A-Z0-9]*)"">(?:<b><font color='#[A-F0-9]{6}'>)?(?'wishlistname'[\w\s]*)(?:</font></b>)?</a>");
            Match matchResult = regexObj.Match(html);
            while (matchResult.Success)
            {
                wishlists.Add(new Wishlist(matchResult.Groups["wishlistname"].Value, matchResult.Groups["amazonId"].Value));
                matchResult = matchResult.NextMatch();
            }

            return wishlists;
        }
    }
}
