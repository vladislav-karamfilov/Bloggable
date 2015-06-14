namespace Bloggable.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public class DefaultMigrationConfiguration : DbMigrationsConfiguration<BloggableDbContext>
    {
        public DefaultMigrationConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }
    }
}
