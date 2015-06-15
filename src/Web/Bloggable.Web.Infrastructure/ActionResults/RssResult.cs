namespace Bloggable.Web.Infrastructure.ActionResults
{
    using System.Collections.Generic;
    using System.ServiceModel.Syndication;
    using System.Web;
    using System.Web.Mvc;
    using System.Xml;

    using Bloggable.Common.Constants;

    public class RssResult : FileResult
    {
        private readonly SyndicationFeed feed;

        public RssResult(SyndicationFeed feed)
            : base(ContentTypeConstants.RssXml)
        {
            this.feed = feed;
        }

        public RssResult(string title, string description, IEnumerable<SyndicationItem> feedItems)
            : this(new SyndicationFeed(title, description, HttpContext.Current.Request.Url) { Items = feedItems })
        {
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            var xmlWriterSettings = new XmlWriterSettings { Indent = true, NewLineHandling = NewLineHandling.Entitize };
            using (var writer = XmlWriter.Create(response.OutputStream, xmlWriterSettings))
            {
                this.feed.GetRss20Formatter().WriteTo(writer);
            }
        }
    }
}
