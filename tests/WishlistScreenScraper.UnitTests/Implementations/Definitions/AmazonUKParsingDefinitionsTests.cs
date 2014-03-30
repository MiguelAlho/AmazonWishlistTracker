using AmazonWishlistTracker.WishlistScreenScraper.Implementation.Definitions;
using AmazonWishlistTracker.WishlistScreenScraper.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistScreenScraper.UnitTests.Implementations
{
    [TestFixture]
    public class AmazonUKParsingDefinitionsTests
    {
        [Test]
        public void CanCreateInstanceOfAmazonUKParsingDefinitions()
        {
            IWishlistParsingDefinitions def = new AmazonUKParsingDefinitions();
            Assert.IsNotNull(def);
            Assert.IsInstanceOf<IWishlistParsingDefinitions>(def);
            Assert.IsInstanceOf<AmazonUKParsingDefinitions>(def);
        }

        [Test]
        public void CanGetWishlistCollectionUri()
        {
            var definitions = new AmazonUKParsingDefinitions();

            Uri uri = definitions.WishlistCollectionUri;

            Assert.IsNotNull(uri);
            Assert.AreEqual(AmazonUKParsingDefinitions.WishlistCollectionUrlString, uri.OriginalString);
        }

        [Test]
        public void CanGetWishlistRegex()
        {
            var regex = new AmazonUKParsingDefinitions().WishlistCollectionRegex;

            Assert.IsNotNull(regex);
        }

        [Test]
        public void CanGetWishlistMatchMapper()
        {
            var mapper = new AmazonUKParsingDefinitions().WishlistMatchMapperFunc;

            Assert.IsNotNull(mapper);
        }

        [TestCase("20E6BOWWE0J4T", 1, "http://www.amazon.co.uk/gp/aw/ls/ref=aw_ls_1?lid=20E6BOWWE0J4T&p=1&reveal=unpurchased&sort=date-added&ty=wishlist")]
        [TestCase("50E6BOWWE0J4T", 2, "http://www.amazon.co.uk/gp/aw/ls/ref=aw_ls_2?lid=50E6BOWWE0J4T&p=2&reveal=unpurchased&sort=date-added&ty=wishlist")]
        public void CanGetBookListUriForWishlistAtPage(string wishlist, int page, string expectedUrl)
        {
            Uri uri = new AmazonUKParsingDefinitions().BookListUriForWishlistAtPage(wishlist, page);

            Assert.AreEqual(expectedUrl, uri.OriginalString);
        }

        [Test]
        public void CanGetBooklistRegex()
        {
            var regex = new AmazonUKParsingDefinitions().BookListItemRegex;

            Assert.IsNotNull(regex);
        }

        [Test]
        public void CanGetBooklistPageCountRegex()
        {
            var regex = new AmazonUKParsingDefinitions().BookListPageCountRegex;
            Assert.IsNotNull(regex);
        }

        [TestCase("0321534468", 1, "http://www.amazon.co.uk/gp/offer-listing/0321534468/sr=/qid=/ref=olp_page_1?ie=UTF8&colid=&coliid=&condition=all&me=&qid=&shipPromoFilter=0&sort=sip&sr=&startIndex=0")]
        [TestCase("0321534468", 2, "http://www.amazon.co.uk/gp/offer-listing/0321534468/sr=/qid=/ref=olp_page_2?ie=UTF8&colid=&coliid=&condition=all&me=&qid=&shipPromoFilter=0&sort=sip&sr=&startIndex=10")]
        public void CanGetOfferListingUriForBookAtPage(string bookId, int page, string expectedUrl)
        {
            Uri uri = new AmazonUKParsingDefinitions().OfferListingUriForBookAtPage(bookId, page);

            Assert.AreEqual(expectedUrl, uri.OriginalString);
        }

        [Test]
        public void CanGetOfferToQuoteMatchMapper()
        {
            var mapper = new AmazonUKParsingDefinitions().OfferToQuoteMapperFunc;

            Assert.IsNotNull(mapper);
        }
    }
}
