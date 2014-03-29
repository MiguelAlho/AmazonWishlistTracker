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
    public class WishlistTests
    {
        [Test]
        public void CanCreateInstanceOfWishlist()
        {
            var name = "Business";
            var amazonId = "13WMOM3XTAK5G";

            var instance = new Wishlist(name, amazonId);

            Assert.IsNotNull(instance);
            Assert.AreEqual(name, instance.Name);
            Assert.AreEqual(amazonId, instance.AwId);
        }
    }
}
