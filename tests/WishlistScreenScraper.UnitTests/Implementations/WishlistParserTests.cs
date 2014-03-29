using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AmazonWishlistTracker.WishlistScreenScraper.Implementation;
using AmazonWishlistTracker.WishlistScreenScraper.Interfaces;
using Microsoft.Win32;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using NSubstitute;
using AmazonWishlistTracker.WishlistScreenScraper.Infrastructure;
using AmazonWishlistTracker.WishlistScreenScraper.Dto;

namespace WishlistScreenScraper.UnitTests.Implementations
{
    [TestFixture]
    public class WishlistParserTests
    {
        [Test]
        public void CanCreateInstanceOfWishlistParser()
        {
            IWishlistParsingDefinitions definitions = Substitute.For<IWishlistParsingDefinitions>();
            IWebClient webClientMock = Substitute.For<IWebClient>();

            IWishlistParser parser = new WishlistParser(definitions, webClientMock);

            Assert.IsNotNull(parser);
            Assert.IsInstanceOf<IWishlistParser>(parser);
            Assert.IsInstanceOf<WishlistParser>(parser);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWishlistParserWithNullDefinitionsThrowsException()
        {
            IWishlistParsingDefinitions definitions = Substitute.For<IWishlistParsingDefinitions>();
            IWebClient webClientMock = Substitute.For<IWebClient>();

            IWishlistParser parser = new WishlistParser(null, webClientMock);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWishlistParserWithNullWebClientThrowsException()
        {
            IWishlistParsingDefinitions definitions = Substitute.For<IWishlistParsingDefinitions>();
            IWebClient webClientMock = Substitute.For<IWebClient>();

            IWishlistParser parser = new WishlistParser(definitions, null);
        }
        
        
        [Test]
        public void CanGetAListOfWishLists()
        {
            IWishlistParsingDefinitions definitions = Substitute.For<IWishlistParsingDefinitions>();
            var webClientMock = WebClientMockForWishList();

            IWishlistParser parser = new WishlistParser(definitions, webClientMock);
            IList<Wishlist> wishlists = parser.GetWishlistsForUser("user@domain.com");

            Assert.IsNotNull(wishlists);
            Assert.IsNotEmpty(wishlists);

            Assert.AreEqual(2, wishlists.Count);

            Wishlist first = wishlists.First();
            Assert.IsNotNull(first);
            Assert.AreEqual("Business", first.Name);
            Assert.AreEqual("13WMOM3XTAK5G", first.AwId);
            
            Wishlist second = wishlists[1];
            Assert.IsNotNull(second);
            Assert.AreEqual("Methodologies", second.Name);
            Assert.AreEqual("20E6BOWWE0J4T", second.AwId);
        }

        private static IWebClient WebClientMockForWishList()
        {
            string html = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Data\ls_2wishlists.txt"));
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(html);

            IWebClient webClientMock = Substitute.For<IWebClient>();
            webClientMock.DownloadData(Arg.Any<Uri>()).Returns(bytes);
            return webClientMock;
        }
    }
}
