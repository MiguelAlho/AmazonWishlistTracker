using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AmazonWishlistTracker.WishlistScreenScraper.Implementation;
using AmazonWishlistTracker.WishlistScreenScraper.Implementation.Definitions;
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
            IWishlistParsingDefinitions definitions = new AmazonUKParsingDefinitions();

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

        [Test]
        public void CanGetAListOfBooksForAWishlist()
        {
            IWishlistParsingDefinitions definitions = new AmazonUKParsingDefinitions();
            var webClientMock = WebClientMockForBookList();

            IWishlistParser parser = new WishlistParser(definitions, webClientMock);
            IList<ScrapedBook> books = parser.GetBookListForWishlist("20E6BOWWE0J4T");

            Assert.IsNotNull(books);
            Assert.IsNotEmpty(books);
            Assert.AreEqual(35, books.Count);

            ScrapedBook first = books[0];
            Assert.IsNotNull(first);
            Assert.AreEqual("0321534468", first.Id);
            Assert.AreEqual("20E6BOWWE0J4T", first.WishlistId);
            Assert.AreEqual("Agile Testing: A Practical Guide for Testers and Agile Teams (Addison-Wesley Signature) (Paperback)", first.Title);
            Assert.IsTrue(first.AwPrice.HasValue);
            Assert.AreEqual(36.99M, first.AwPrice.Value);

            ScrapedBook nullpricebook = books[2];
            Assert.IsNotNull(nullpricebook);
            Assert.AreEqual("0321554132", nullpricebook.Id);
            Assert.AreEqual("20E6BOWWE0J4T", nullpricebook.WishlistId);
            Assert.AreEqual("Managing Software Debt: Building for Inevitable Change (Agile Software Development) (Hardcover)", nullpricebook.Title);
            Assert.IsFalse(nullpricebook.AwPrice.HasValue);
        }

        private static IWebClient WebClientMockForBookList()
        {
            string html1 = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Data\methedologies_booklist_p1.txt"));
            string html2 = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Data\methedologies_booklist_p2.txt"));
            byte[] bytes1 = System.Text.Encoding.UTF8.GetBytes(html1);
            byte[] bytes2 = System.Text.Encoding.UTF8.GetBytes(html2);

            IWebClient webClientMock = Substitute.For<IWebClient>();
            webClientMock.DownloadData(Arg.Is<Uri>(o => o.OriginalString.Contains("&p=1&"))).Returns(bytes1);
            webClientMock.DownloadData(Arg.Is<Uri>(o => o.OriginalString.Contains("&p=2&"))).Returns(bytes2);
            return webClientMock;
        }

    }
}
