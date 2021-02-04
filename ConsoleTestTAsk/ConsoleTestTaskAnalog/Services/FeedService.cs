using ConsoleTestTaskAnalog.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTestTaskAnalog.Services
{
    public class FeedService : IFeedService
    {
        private readonly FeedDownloader _feedDownloader;

        public FeedService()
        {
            _feedDownloader = new FeedDownloader();

            _feedDownloader.DownloadCompleted += (result) =>
            {
                foreach (var title in result)
                    Console.WriteLine(title);
            };
        }

        public async Task Run(string[] urls)
        {
            var tasks = urls.Select(_feedDownloader.DownloadFeedAsync);
            var results = await Task.WhenAll(tasks);
        }
    }
}
