using System.IO;
using AmazonWishlistTracker.WishlistScreenScraper.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AmazonWishlistTracker.Specs.Infrastucture.Fakes
{
    /// <summary>
    /// based on : http://brunov.info/blog/2013/07/30/tdd-mocking-system-net-webclient/
    /// used for testing
    /// </summary>
    class FakeWebClient : IWebClient
    {
        // Required methods (subset of `System.Net.WebClient` methods).
        public byte[] DownloadData(Uri address)
        {
            string file;
            switch (address.OriginalString)
            {
                case "http://www.amazon.co.uk/gp/aw/ls":;
                    file = "ls.txt";
                    break;
                case "http://www.amazon.co.uk/gp/aw/ls/ref=aw_ls_1?lid=20E6BOWWE0J4T&p=1&reveal=unpurchased&sort=date-added&ty=wishlist":
                    file = "methedologies_booklist_p1.txt";
                    break;
                case "http://www.amazon.co.uk/gp/aw/ls/ref=aw_ls_2?lid=20E6BOWWE0J4T&p=2&reveal=unpurchased&sort=date-added&ty=wishlist":
                    file = "methedologies_booklist_p2.txt";
                    break;
                case "http://www.amazon.co.uk/gp/offer-listing/0321534468/sr=/qid=/ref=olp_page_1?ie=UTF8&colid=&coliid=&condition=all&me=&qid=&shipPromoFilter=0&sort=sip&sr=&startIndex=0":
                    file = "AllOffers_AgileTesting.txt";
                    break;
                default:
                    throw new ArgumentException("uri is invalid");
            }

            string path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Files\", file);
            string content = File.ReadAllText(path);
            return Encoding.UTF8.GetBytes(content);
        }

        public byte[] UploadData(Uri address, byte[] data)
        {
            throw new NotImplementedException("no uploads happening...");
        }
    }
}
