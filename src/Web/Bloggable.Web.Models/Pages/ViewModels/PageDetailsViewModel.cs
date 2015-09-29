namespace Bloggable.Web.Models.Pages.ViewModels
{
    using System;

    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class PageDetailsViewModel : IMapFrom<Page>
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Content { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
