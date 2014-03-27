using System;
using TechTalk.SpecFlow;

namespace AmazonWishlistTracker.Specs.scraper.steps
{
    [Binding]
    public class ScraperMetaDataFetchSteps
    {
        [Given(@"I have configured my scraper with:")]
        public void GivenIHaveConfiguredMyScraperWith(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I retrieve metadata for the scraper")]
        public void WhenIRetrieveMetadataForTheScraper()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the scraper should know that there are the following wishlists:")]
        public void ThenTheScraperShouldKnowThatThereAreTheFollowingWishlists(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
