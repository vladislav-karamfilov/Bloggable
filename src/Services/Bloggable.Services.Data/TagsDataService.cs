namespace Bloggable.Services.Data
{
    using System.Linq;

    using Bloggable.Data.Contracts.Repositories;
    using Bloggable.Data.Models;
    using Bloggable.Services.Data.Contracts;

    public class TagsDataService : ITagsDataService
    {
        private readonly IRepository<Tag> tags;

        public TagsDataService(IRepository<Tag> tags)
        {
            this.tags = tags;
        }

        public Tag GetByNameOrCreate(string name)
        {
            var tag = this.tags.All().FirstOrDefault(t => t.Name == name);
            
            if (tag == null)
            {
                tag = new Tag { Name = name };
                this.tags.Add(tag);
                this.tags.SaveChanges();
            }

            return tag;
        }
    }
}
