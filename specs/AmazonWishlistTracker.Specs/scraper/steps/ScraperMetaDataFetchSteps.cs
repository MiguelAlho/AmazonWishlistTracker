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
        private IWishlistParser client;
        private IList<Wishlist> wishlists;
        private WishlistScraperConfiguration config;

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

                Assert.IsTrue(wishlists.Any(o => o.AwId.ToString() == expectedId && o.Name.ToString() == expectedName), "could not find {0},{1} in list", expectedName, expectedId);
            }
        }
    }
}
