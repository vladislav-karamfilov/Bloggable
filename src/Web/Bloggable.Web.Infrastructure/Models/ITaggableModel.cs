namespace Bloggable.Web.Infrastructure.Models
{
    using System.Collections.Generic;

    using Bloggable.Data.Models;

    public interface ITaggableModel
    {
        string MergedTags { get; set; }
        
        ICollection<Tag> Tags { get; set; }
    }
}
