using AmazonWishlistTracker.WishlistScreenScraper.Dto;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistScreenScraper.UnitTests.Dto
{
    [TestFixture]
    public class ScrapedBookTests
    {
        [Test]
        public void CanCreateInstanceOfScrapedBookWithValidPrice()
        {
            var expectedBookId = "0321534468";
            var expectedListId = "20E6BOWWE0J4T";
            var expectedTitle = "Agile Testing: A Practical ...";
            var expectedAwPrice = 36.99M;

            var book = new ScrapedBook(expectedBookId, expectedListId, expectedTitle, expectedAwPrice);

            Assert.IsNotNull(book);
            Assert.AreEqual(expectedBookId, book.Id);
            Assert.AreEqual(expectedListId, book.WishlistId);
            Assert.AreEqual(expectedTitle, book.Title);
            Assert.AreEqual(expectedAwPrice, book.AwPrice);
        }

        [Test]
        public void CanCreateInstanceOfScrapedBookWithNullPrice()
        {
            var expectedBookId = "0321534468";
            var expectedListId = "20E6BOWWE0J4T";
            var expectedTitle = "Managing Software Debt...";
            decimal? expectedAwPrice = null;

            var book = new ScrapedBook(expectedBookId, expectedListId, expectedTitle, expectedAwPrice);

            Assert.IsNotNull(book);
            Assert.AreEqual(expectedBookId, book.Id);
            Assert.AreEqual(expectedListId, book.WishlistId);
            Assert.AreEqual(expectedTitle, book.Title);
            Assert.AreEqual(expectedAwPrice, book.AwPrice);
        }

        [TestCase(null, "wid", "title")]
        [TestCase("id", null, "title")]
        [TestCase("id", "wid", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullInputsInConstructorThrowException(string expectedBookId, string expectedListId, string expectedTitle)
        {
            var expectedAwPrice = 36.99M;   //can't be passed as test case arg; 
            var book = new ScrapedBook(expectedBookId, expectedListId, expectedTitle, expectedAwPrice);
        }
       
    }
}
