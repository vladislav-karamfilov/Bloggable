namespace Bloggable.Web.Models.Pages.ViewModels
{
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class PageViewModel : IMapFrom<Page>
    {
        public int Id { get; set; }

        public string Permalink { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }
    }
}
