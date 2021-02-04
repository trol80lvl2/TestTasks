using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using ConsoleTestTaskAnalog.Data.Interfaces;

namespace ConsoleTestTaskAnalog.Data
{
    class FeedXmlRepository : IFeedRepository
    {
        private string _fileName;

        public FeedXmlRepository()
        {
            _fileName = "feeds.xml";
        }

        public FeedXmlRepository(string fileName)
        {
            _fileName = fileName;
        }

        public void Create(Feed feed)
        {
            var document = GetDocument(_fileName);

            XElement element = new XElement("Feed");
            element.Add(new XAttribute("Name", feed.Name));
            element.Add(new XAttribute("Url", feed.Url));
            document.Element("Feeds").Add(element);

            document.Save(_fileName);
        }

        public IList<Feed> GetAll()
        {
            var document = GetDocument(_fileName);

            var feeds = from feed in document.Descendants("Feed")
                        select new Feed()
                        {
                            Name = feed.Attribute("Name").Value,
                            Url = feed.Attribute("Url").Value
                        };

            return feeds.ToList();
        }

        public IList<Feed> GetByName(string name)
        {
            return GetAll().Where(f => f.Name == name).ToList();
        }

        public void Delete(string name)
        {
            var document = GetDocument(_fileName);

            document.Descendants("Feed")
                .Where(f => f.Attribute("Name").Value == name)
                .Remove();

            document.Save(_fileName);
        }

        private XDocument GetDocument(string documentName)
        {
            XDocument document = new XDocument(new XElement("Feeds"));

            if (!File.Exists(documentName))
                document.Save(documentName);
            else
                document = XDocument.Load(documentName);

            return document;
        }

    }
}
