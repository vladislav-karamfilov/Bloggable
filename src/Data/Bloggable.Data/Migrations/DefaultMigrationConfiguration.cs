namespace Bloggable.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class DefaultMigrationConfiguration : DbMigrationsConfiguration<BloggableDbContext>
    {
        public DefaultMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BloggableDbContext context)
        {
            this.SeedSystemSettings(context);
            this.SeedRoles(context);

            if (context.Users.Any())
            {
                this.SeedPosts(context);

                //// TODO: Seed comments and pages.
            }

            context.SaveChanges();
        }

        private void SeedSystemSettings(IBloggableDbContext context)
        {
            context.Settings.AddOrUpdate(s => s.Id, new Setting { Id = AppSettingConstants.BlogNameSetting, Value = "VBlog" });
            context.Settings.AddOrUpdate(
                s => s.Id,
                new Setting
                {
                    Id = AppSettingConstants.BlogDescriptionSetting,
                    Value = "Vladislav Karamfilov's blog for programming, science and others"
                });
            context.Settings.AddOrUpdate(
                s => s.Id,
                new Setting
                {
                    Id = AppSettingConstants.BlogKeywordsSetting,
                    Value = "blog, programming, science, .NET, C#, ASP.NET MVC, Node.js"
                });
        }

        private void SeedRoles(BloggableDbContext context)
        {
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole(RoleConstants.Administrator));
        }

        private void SeedPosts(BloggableDbContext context)
        {
            if (!context.Posts.Any())
            {
                var userId = context.Users.First().Id;
                for (var i = 0; i < 10; i++)
                {
                    context.Posts.Add(
                        new Post
                        {
                            Content = @"<p><strong>Lorem Ipsum</strong> is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>" + i,
                            AuthorId = userId,
                            MetaDescription = "Lorem Ipsum meta descriptiopn" + i,
                            Title = "Blog post " + i,
                            SubTitle = i % 2 == 0 ? "Blog sub title " + i : null,
                            MetaKeywords = "blog, post, seed, " + i
                        });
                }
            }
        }
    }
}
