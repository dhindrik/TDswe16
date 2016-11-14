using System;

namespace XamarinNews.Core
{
    public class NewsItem
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public DateTime PublishDate { get; set; }
    }
}