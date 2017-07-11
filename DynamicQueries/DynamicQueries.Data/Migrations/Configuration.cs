namespace DynamicQueries.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<DynamicQueries.Data.DynamicQueriesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DynamicQueries.Data.DynamicQueriesContext context)
        {
            context.Sources.AddOrUpdate(
              new Source { Name = "Chat" },
              new Source { Name = "Facebook" },
              new Source { Name = "Twitter" },
              new Source { Name = "Advertisement" }
            );
        }
    }
}
