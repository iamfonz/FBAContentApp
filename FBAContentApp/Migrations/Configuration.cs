namespace FBAContentApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FBAContentApp.Models.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FBAContentApp.Models.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.States.AddOrUpdate(x => x.Id,
                new Entities.State() { Id = 1, Abbreviation = "AL", FullName = "Alabama" },
                new Entities.State() { Id = 2, Abbreviation = "AK", FullName = "Alaska" },
                new Entities.State() { Id = 3, Abbreviation = "AZ", FullName = "Arizona" },
                new Entities.State() { Id = 4, Abbreviation = "AR", FullName = "Arkansas" },
                new Entities.State() { Id = 5, Abbreviation = "CA", FullName = "California" },
                new Entities.State() { Id = 6, Abbreviation = "CO", FullName = "Colorado" },
                new Entities.State() { Id = 7, Abbreviation = "CT", FullName = "Connecticut" },
                new Entities.State() { Id = 8, Abbreviation = "DE", FullName = "Delaware" },
                new Entities.State() { Id = 9, Abbreviation = "FL", FullName = "Florida" },
                new Entities.State() { Id = 10, Abbreviation = "GA", FullName = "Georgia" },
                new Entities.State() { Id = 11, Abbreviation = "HI", FullName = "Hawaii" },
                new Entities.State() { Id = 12, Abbreviation = "ID", FullName = "Idaho" },
                new Entities.State() { Id = 13, Abbreviation = "IL", FullName = "Illinois" },
                new Entities.State() { Id = 14, Abbreviation = "IN", FullName = "Indiana" },
                new Entities.State() { Id = 15, Abbreviation = "IA", FullName = "Iowa" },
                new Entities.State() { Id = 16, Abbreviation = "KS", FullName = "Kansas" },
                new Entities.State() { Id = 17, Abbreviation = "KY", FullName = "Kentucky" },
                new Entities.State() { Id = 18, Abbreviation = "LA", FullName = "Louisiana" },
                new Entities.State() { Id = 19, Abbreviation = "ME", FullName = "Maine" },
                new Entities.State() { Id = 20, Abbreviation = "MD", FullName = "Maryland" },
                new Entities.State() { Id = 21, Abbreviation = "MA", FullName = "Massachusetts" },
                new Entities.State() { Id = 22, Abbreviation = "MI", FullName = "Michigan" },
                new Entities.State() { Id = 23, Abbreviation = "MN", FullName = "Minnesota" },
                new Entities.State() { Id = 24, Abbreviation = "MS", FullName = "Mississippi" },
                new Entities.State() { Id = 25, Abbreviation = "MO", FullName = "Missouri" },
                new Entities.State() { Id = 26, Abbreviation = "MT", FullName = "Montana" },
                new Entities.State() { Id = 27, Abbreviation = "NE", FullName = "Nebraska" },
                new Entities.State() { Id = 28, Abbreviation = "NV", FullName = "Nevada" },
                new Entities.State() { Id = 29, Abbreviation = "NH", FullName = "New Hampshire" },
                new Entities.State() { Id = 30, Abbreviation = "NJ", FullName = "New Jersey" },
                new Entities.State() { Id = 31, Abbreviation = "NM", FullName = "New Mexico" },
                new Entities.State() { Id = 32, Abbreviation = "NY", FullName = "New York" },
                new Entities.State() { Id = 33, Abbreviation = "NC", FullName = "North Carolina" },
                new Entities.State() { Id = 34, Abbreviation = "ND", FullName = "North Dakota" },
                new Entities.State() { Id = 35, Abbreviation = "OH", FullName = "Ohio" },
                new Entities.State() { Id = 36, Abbreviation = "OK", FullName = "Oklahoma" },
                new Entities.State() { Id = 37, Abbreviation = "OR", FullName = "Oregon" },
                new Entities.State() { Id = 38, Abbreviation = "PA", FullName = "Pennsylvania" },
                new Entities.State() { Id = 39, Abbreviation = "RI", FullName = "Rhode Island" },
                new Entities.State() { Id = 40, Abbreviation = "SC", FullName = "South Carolina" },
                new Entities.State() { Id = 41, Abbreviation = "SD", FullName = "South Dakota" },
                new Entities.State() { Id = 42, Abbreviation = "TN", FullName = "Tennessee" },
                new Entities.State() { Id = 43, Abbreviation = "TX", FullName = "Texas" },
                new Entities.State() { Id = 44, Abbreviation = "UT", FullName = "Utah" },
                new Entities.State() { Id = 45, Abbreviation = "VT", FullName = "Vermont" },
                new Entities.State() { Id = 46, Abbreviation = "VA", FullName = "Virgina" },
                new Entities.State() { Id = 47, Abbreviation = "WA", FullName = "Washington" },
                new Entities.State() { Id = 48, Abbreviation = "WV", FullName = "West Virginia" },
                new Entities.State() { Id = 49, Abbreviation = "WI", FullName = "Wisconsin" },
                new Entities.State() { Id = 50, Abbreviation = "WY", FullName = "Wyoming" }
                );
        }
    }
}
