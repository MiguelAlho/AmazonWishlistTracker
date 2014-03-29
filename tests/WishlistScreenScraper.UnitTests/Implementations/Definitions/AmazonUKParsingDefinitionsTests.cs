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
    }
}
