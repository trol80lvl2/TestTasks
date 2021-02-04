using System.Linq;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using System;
using ConsoleTestTaskAnalog.Services.Interfaces;

namespace ConsoleTestTaskAnalog.Services
{
    public class FeedDownloader : IFeedDownloader
    {
        public event Action<IEnumerable<string>> DownloadCompleted;

        public IEnumerable<string> DownloadFeed(string url)
        {
            XmlReader _reader;
            _reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(_reader);
            _reader.Close();

            var result = feed.Items.Select(f => f.Title.Text).ToArray();

            DownloadCompleted(result);

            return result;
        }

        public async Task<IEnumerable<string>> DownloadFeedAsync(string url)
        {
            return await Task.Run(() => DownloadFeed(url));
        }
    }
}
