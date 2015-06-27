namespace Bloggable.Web.Models.Common
{
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class TagViewModel : IMapFrom<Tag>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
