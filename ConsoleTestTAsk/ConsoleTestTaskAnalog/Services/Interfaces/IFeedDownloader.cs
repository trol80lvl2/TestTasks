using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleTestTaskAnalog.Services.Interfaces
{
    public interface IFeedDownloader
    {
        IEnumerable<string> DownloadFeed(string url);
        Task<IEnumerable<string>> DownloadFeedAsync(string url);
    }
}
