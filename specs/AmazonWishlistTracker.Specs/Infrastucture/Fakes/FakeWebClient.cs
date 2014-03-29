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
                case "http://www.amazon.co.uk/gp/aw/ls":
                    file = "ls.txt";
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
