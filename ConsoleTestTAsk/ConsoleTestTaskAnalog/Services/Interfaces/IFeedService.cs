using System.Threading.Tasks;

namespace ConsoleTestTaskAnalog.Services.Interfaces
{
    public interface IFeedService
    {
        Task Run(string[] urls);
    }
}
