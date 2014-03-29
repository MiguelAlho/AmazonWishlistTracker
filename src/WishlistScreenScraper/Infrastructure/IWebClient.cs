using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWishlistTracker.WishlistScreenScraper.Infrastructure
{
    ///wrapping interface to work around WebClient's untestability...
    public interface IWebClient
    {
        // Required methods (subset of `System.Net.WebClient` methods).
        byte[] DownloadData(Uri address);
        byte[] UploadData(Uri address, byte[] data);
    }
}
