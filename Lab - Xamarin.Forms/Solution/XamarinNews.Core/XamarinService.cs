using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XamarinNews.Core
{
    public class XamarinService
    {
        public async static Task<List<NewsItem>> Get()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://blog.xamarin.com/feed/");

            var doc = XDocument.Parse(result);

            var entries = from item in doc.Root.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item")
                      select new NewsItem
                      {
                          Text = item.Elements().First(i => i.Name.LocalName == "description").Value,
                          Url = item.Elements().First(i => i.Name.LocalName == "link").Value,
                          PublishDate = DateTime.Parse(item.Elements().First(i => i.Name.LocalName == "pubDate").Value),
                          Title = item.Elements().First(i => i.Name.LocalName == "title").Value
                      };

            return entries.ToList();
        }

       
    }
}
