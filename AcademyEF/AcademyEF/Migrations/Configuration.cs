namespace AcademyEF.Migrations
{
    using AcademyEF.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AcademyEF.AcademyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AcademyEF.AcademyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            User admin = new User("admin", "admin", "admin@mail.com", true, "admin", "Adminov");

            User user = new User("user", "user", "user@mail.com", true, "user", "user");

            context.Users.AddOrUpdate(
              p => p.Username,
              admin, user
            );
        }
    }
}
