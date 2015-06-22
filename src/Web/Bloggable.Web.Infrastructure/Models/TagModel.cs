namespace Bloggable.Web.Infrastructure.Models
{
    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class TagModel : IMapFrom<Tag>, IMapTo<Tag>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as TagModel;
            return other != null && other.Id == this.Id;
        }
    }
}
