using ConsoleTestTAsk;
using ConsoleTestTaskAnalog.Data;
using ConsoleTestTaskAnalog.Data.Interfaces;
using ConsoleTestTaskAnalog.Services;
using ConsoleTestTaskAnalog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTestTaskAnalog
{
    class Program
    {
        private static IFeedRepository _feedRepository;

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CommandsParser commandParser = new CommandsParser();
            IFeedService feedService = new FeedService();
            _feedRepository = new FeedXmlRepository();
            string[] arrString;
            //_feedRepository.Create(new Feed() { Name = "news", Url = "https://www.liga.net/news/rss.xml" });
            //_feedRepository.Create(new Feed() { Name = "articles", Url = "https://www.liga.net/news/articles/rss.xml" });
            //_feedRepository.Create(new Feed() { Name = "interview", Url = "https://www.liga.net/news/interview/rss.xml" });
            //_feedRepository.Create(new Feed() { Name = "opinion", Url = "https://www.liga.net/opinion/rss.xml" });
            //_feedRepository.Create(new Feed() { Name = "crypto", Url = "https://www.liga.net/fin/crypto/rss.xml" });
            //_feedRepository.Create(new Feed() { Name = "blog", Url = "https://www.liga.net/rss/blog.xml" });
            //_feedRepository.Create(new Feed() { Name = "vlog", Url = "https://www.liga.net/tech/vlog/rss.xml" });

            //_feedRepository.Create(new Feed() { Name = "news2.0", Url = "https://www.liga.net/news/rss.xml" });
            //var result = _feedRepository.GetAll();
            //var res = _feedRepository.GetByName("news2.0");
            //_feedRepository.Delete("news2.0");
            while (true)
            {
                do
                {
                    Console.Write("Enter the command->");
                }
                while (!commandParser.TryParse(Console.ReadLine(), out arrString));

                try
                {
                    switch (arrString[0].ToLower())
                    {
                        case "add":
                            _feedRepository.Create(new Feed {Name = arrString[1], Url = arrString[2] });
                            Console.WriteLine("Feed added");
                            break;
                        case "remove":
                            _feedRepository.Delete(arrString[1]);
                            Console.WriteLine("Feed removed");
                            break;
                        case "download":
                            var feeds = _feedRepository.GetAll();
                            if(feeds.Count == 0)
                            {
                                Console.WriteLine("XML-file with feeds is empty");
                                continue;
                            }
                            IList<string> names = new List<string>();
                            for (int i = 1; i < arrString.Length; i++)
                            {
                                if (feeds.Where(x => x.Name == arrString[i]).Count() > 0)
                                    names.Add(feeds.Where(x=>x.Name == arrString[i]).Select(x => x.Url).FirstOrDefault());
                            }
                            if (names.Count < 1)
                            {
                                Console.WriteLine("Nothing was found");
                                continue;
                            }
                                
                            await feedService.Run(names.ToArray());
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            //var feeds = _feedRepository.GetAll();
            //string[] urls = feeds.Select(f => f.Url).ToArray();


            //await feedService.Run(urls);
        }
    }
}
