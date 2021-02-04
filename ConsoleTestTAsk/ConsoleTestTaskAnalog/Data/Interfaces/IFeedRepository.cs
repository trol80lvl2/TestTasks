using System.Collections.Generic;

namespace ConsoleTestTaskAnalog.Data.Interfaces
{
    public interface IFeedRepository
    {
        IList<Feed> GetByName(string name);
        IList<Feed> GetAll();
        void Create(Feed feed);
        void Delete(string name);
    }
}
