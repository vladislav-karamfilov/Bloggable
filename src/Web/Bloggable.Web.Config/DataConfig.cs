namespace Bloggable.Web.Config
{
    using System.Data.Entity;

    using Bloggable.Data;
    using Bloggable.Data.Migrations;

    public class DataConfig
    {
        public static void ConfigureData()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BloggableDbContext, DefaultMigrationConfiguration>(true));
        }
    }
}
