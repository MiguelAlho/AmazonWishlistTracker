using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using AmazonWishlistTracker.WishlistScreenScraper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonWishlistTracker.WishlistScreenScraper.Dto;

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
                @"<a href=""/gp/aw/ls/ref=aw_ls\?lid=(?'amazonId'[A-Z0-9]*)"">(?:<b><font color='#[A-F0-9]{6}'>)?(?'wishlistname'[\w\s]*)(?:</font></b>)?</a>");

        private const string wishklistRegex_name = "wishlistname";
        private const string wishklistRegex_awid = "amazonId";

        #endregion


        public const string WishlistCollectionUrlString = @"http://www.amazon.co.uk/gp/aw/ls";

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
                return new Func<Match, Wishlist>(Match => new Wishlist(Match.Groups[wishklistRegex_name].Value, Match.Groups[wishklistRegex_awid].Value));
            }
        }

    }
}
