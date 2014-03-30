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
    public class QuoteTests
    {
        [Test]
        public void CanCreateInstanceOfScrapedBookWithValidPrice()
        {
            var expectedBookId = "0321534468";
            var expectedSellerId = "A3A72FJ03Q9CJT";
            var expectedSellerName = "UKPaperbackshop";
            var expectedSellerPrice = 21.64M;   //null seller price makes no sense
            var expectedCondition = "New";

            var quote = new Quote(expectedBookId, expectedSellerId, expectedSellerName, expectedSellerPrice, expectedCondition);

            Assert.IsNotNull(quote);
            Assert.AreEqual(expectedBookId, quote.BookId);
            Assert.AreEqual(expectedSellerId, quote.SellerId);
            Assert.AreEqual(expectedSellerName, quote.SellerName);
            Assert.AreEqual(expectedSellerPrice, quote.Price);
            Assert.AreEqual(expectedCondition, quote.Condition);
        }

        [TestCase(null, "sid", "seller", "Old")]
        [TestCase("bid", null, "seller", "New")]
        [TestCase("bid", "sid", null, "New")]
        [TestCase("bid", "sid", "seller", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullInputsInConstructorThrowException(string expectedBookId, string expectedSellerId, string expectedSellerName, string expectedCondition)
        {
            var expectedPrice = 36.99M;   //can't be passed as test case arg; 
            new Quote(expectedBookId, expectedSellerId, expectedSellerName, expectedPrice, expectedCondition);
        }
    }
}
