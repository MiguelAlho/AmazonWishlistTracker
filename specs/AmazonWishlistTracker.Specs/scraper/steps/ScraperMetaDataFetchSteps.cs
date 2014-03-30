using System.Linq;
using AmazonWishlistTracker.WishlistScreenScraper.Implementation;
using System;
using System.Net;
using AmazonWishlistTracker.WishlistScreenScraper.Interfaces;
using NUnit.Framework;
using TechTalk.SpecFlow;
using AmazonWishlistTracker.WishlistScreenScraper.Infrastructure;
using AmazonWishlistTracker.Specs.Infrastucture.Fakes;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;
using AmazonWishlistTracker.WishlistScreenScraper.Dto;

namespace AmazonWishlistTracker.Specs.scraper.steps
{
    [Binding]
    public class ScraperMetaDataFetchSteps
    {
        private WishlistScraperConfiguration config;
        private IWishlistParser client;
        
        private IList<Wishlist> wishlists;
        private IList<ScrapedBook> booklist;
        private Quote sellerPrice;

        [Given(@"I have configured my scraper with:")]
        public void GivenIHaveConfiguredMyScraperWith(Table table)
        {
            //WishlistScraperConfiguration config = new WishlistScraperConfiguration()
            //{
            //    AmazonTarget = AmazonTargets.UK,
            //    Email = "alho@miguelalho.com"
            //};
            config = table.CreateInstance<WishlistScraperConfiguration>();
            IWishlistParsingDefinitions definitions = WishlistParsingDefinitionsFactory.GetDefinitionsFor(config);
            IWebClient webClientMock = new FakeWebClient();

            client = new WishlistParser(definitions, webClientMock);
        }

        [When(@"I retrieve the users wishlists")]
        public void WhenIRetrieveTheUsersWishlists()
        {
            wishlists = client.GetWishlistsForUser(config.Email);
        }
        
        [Then(@"the scraper should know that there are the following wishlists:")]
        public void ThenTheScraperShouldKnowThatThereAreTheFollowingWishlists(Table table)
        {
            Assert.AreEqual(table.RowCount, wishlists.Count);

            foreach (var row in table.Rows)
            {
                var expectedName = row[0];
                var expectedId = row[1];
                var expectedBookCount = row[2];

                Assert.IsTrue(wishlists.Any(o => o.AwId.ToString() == expectedId 
                                              && o.Name.ToString() == expectedName
                                              && o.BookCount.ToString() == expectedBookCount), 
                              "could not find {0},{1},{2} in list", expectedName, expectedId, expectedBookCount);
            }
        }


        [When(@"I retrieve the book list for the Methodologies wishlist")]
        public void WhenIRetrieveTheBookListForTheMethodologiesWishlist()
        {
            booklist = client.GetBookListForWishlist("20E6BOWWE0J4T");
        }

        [Then(@"the scraper should find (.*) books in the book list")]
        public void ThenTheScraperShouldFindBooksInTheBookList(int p0)
        {
            Assert.AreEqual(p0, booklist.Count);
        }

        [Then(@"the scraper should know that there are the following books are in the wishlist's list")]
        public void ThenTheScraperShouldKnowThatThereAreTheFollowingBooksAreInTheWishlistSList(Table table)
        {
            foreach (var row in table.Rows)
            {
                var expectedBookId = row[0];
                var expectedBookName = row[1];
                var expectedBookPrice = row[2];

                Assert.IsTrue(booklist.Any(o => o.Id.ToString() == expectedBookId 
                                             && o.Title.ToString() == expectedBookName
                                             && o.AwPrice.ToString() == expectedBookPrice), 
                                "could not find {0},{1}, {2} in list", expectedBookId, expectedBookName, expectedBookPrice);
            }
        }

        [When(@"I retrieve the best internationl offer the Agile Testing Book")]
        public void WhenIRetrieveTheBestOfferTheAgileTestingBook()
        {
            sellerPrice = client.GetBestInternationlOfferFor("0321534468");
        }

        [Then(@"the scraper should return:")]
        public void ThenTheScraperShouldReturn(Table table)
        {
            var row = table.Rows[0];

            var expectedBookId = row[0];
            var expectedPrice = row[1];
            var expectedSellerName = row[2];
            var expectedSellerId = row[3];
            var expectedCondition = row[4];

            Assert.IsNotNull(sellerPrice);
            Assert.AreEqual(expectedBookId, sellerPrice.BookId);
            Assert.AreEqual(expectedPrice, sellerPrice.Price);
            Assert.AreEqual(expectedSellerName, sellerPrice.BookId);
            Assert.AreEqual(expectedSellerId, sellerPrice.BookId);
            Assert.AreEqual(expectedCondition, sellerPrice.Condition);
        }


    }
}
