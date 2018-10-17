namespace Doan_24.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Doan_24.Models.ManagerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled =false;
            ContextKey = "Doan_24.Models.ManagerDbContext";
        }

        protected override void Seed(Doan_24.Models.ManagerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
