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

            // Add a Default company address, incase one isn't made from a user.
            context.CompanyAddresses.AddOrUpdate(x => x.Id,
                new Entities.CompanyAddress() {Id = 0, CompanyName = "Company Name", AddressLine1 = "123 Company Address",
                    City = "Albuquerque", State = context.States.Where(i => i.Id == 31).FirstOrDefault(), ZipCode = "87109"  });

            //Seed AmazonWarehouses with existing ones from previous DB
            context.AmazonWarehouses.AddOrUpdate(x => x.Id,
                new Entities.AmazonWarehouse() { Id = 1, WarehouseCode = "ABE3", Name = "Amazon.com", AddressLine = "650 Boulder Drive", City = "Breinigsville", State = context.States.Where(i => i.Id == 38).FirstOrDefault(), ZipCode=  "18031" },

                new Entities.AmazonWarehouse() { Id = 2, WarehouseCode = "BFI3", Name = "Amazon.com.dedc LLC", AddressLine = "2700 Center Drive", City = "DuPont", State = context.States.Where(i => i.Id == 47).FirstOrDefault(), ZipCode = "98327-9607" },

                new Entities.AmazonWarehouse() { Id = 3, WarehouseCode = "BNA2", Name = "Amazon.com.dedc LLC", AddressLine = "500 DUKE DR", City = "Lebanon", State = context.States.Where(i => i.Id == 42).FirstOrDefault(), ZipCode = "37090" },

                new Entities.AmazonWarehouse() { Id = 4, WarehouseCode = "BNA3", Name = "Amazon.com.dedc LLC", AddressLine = "2020 JOE B JACKSON PKWY", City = "Mufreesboro", State = context.States.Where(i => i.Id == 42).FirstOrDefault(), ZipCode = "37127" },

                new Entities.AmazonWarehouse() { Id = 5, WarehouseCode = "BWI2", Name = "Amazon.com.DEDC LLC", AddressLine = "2010 Broening Hwy", City = "Baltimore", State = context.States.Where(i => i.Id == 20).FirstOrDefault(), ZipCode = "21224" },

                new Entities.AmazonWarehouse() { Id = 6, WarehouseCode = "CHA1", Name = "Amazon.com.dedc LLC", AddressLine = "7200 Discovery Dr", City = "Chattanooga", State = context.States.Where(i => i.Id == 42).FirstOrDefault(), ZipCode = "37416-1757" },

                new Entities.AmazonWarehouse() { Id = 7, WarehouseCode = "CHA2", Name = "Amazon.com", AddressLine = "225 Infinity Dr NW", City = "Charleston", State = context.States.Where(i => i.Id == 42).FirstOrDefault(), ZipCode = "37310"},

                new Entities.AmazonWarehouse() { Id = 8, WarehouseCode = "CMH1", Name = "Amazon.com.dedc LLC", AddressLine = "11999 National Road Sw", City = "Etna", State = context.States.Where(i => i.Id == 35).FirstOrDefault(), ZipCode = "43018" },

                new Entities.AmazonWarehouse() { Id = 9, WarehouseCode = "CMH2", Name = "Amazon.com.dedc LLC", AddressLine = "6050 Gateway Court", City = "Groveport", State = context.States.Where(i => i.Id == 35).FirstOrDefault(), ZipCode = "43125-9016" },

                new Entities.AmazonWarehouse() { Id = 10, WarehouseCode = "CVG1", Name = "Amazon.com", AddressLine = "1155 Worldwide Blvd.", City = "Hebron", State = context.States.Where(i => i.Id == 17).FirstOrDefault(), ZipCode = "41018-8648" },

                new Entities.AmazonWarehouse() { Id = 11, WarehouseCode = "DFW6", Name = "Amazon.com KYDC LLC", AddressLine = "940 W Bethel Road", City = "Coppell", State = context.States.Where(i => i.Id == 43).FirstOrDefault(), ZipCode = "75019-4424" },

                new Entities.AmazonWarehouse() { Id = 12, WarehouseCode = "EWR4", Name = "Amazon.com.DEDC LLC", AddressLine = "50 New Canton Way", City = "Robbinsonville", State = context.States.Where(i => i.Id == 30).FirstOrDefault(), ZipCode = "08691-2350" },

                new Entities.AmazonWarehouse() { Id = 13, WarehouseCode = "FTW1", Name = "Amazon.com.kydc LLC", AddressLine = "33333 LBJ FWY", City = "Dallas", State = context.States.Where(i => i.Id == 43).FirstOrDefault(), ZipCode = "75241-7203" },

                new Entities.AmazonWarehouse() { Id = 14, WarehouseCode = "GSP1", Name = "Amazon.com.dedc LLC", AddressLine = "402 John Dodd Rd", City = "Spartanburg", State = context.States.Where(i => i.Id == 40).FirstOrDefault(), ZipCode = "29303" },

                new Entities.AmazonWarehouse() { Id = 15, WarehouseCode = "IND2", Name = "Amazon.com.indc LLC", AddressLine = "715 Airtech Pkwy", City = "Plainfield", State = context.States.Where(i => i.Id == 14).FirstOrDefault(), ZipCode = "46168" },

                new Entities.AmazonWarehouse() { Id = 16, WarehouseCode = "IND4", Name = "Amazon.com.indc LLC", AddressLine = "710 South Girls School Road", City = "Indianapolis", State = context.States.Where(i => i.Id == 14).FirstOrDefault(), ZipCode = "46231-1132" },

                new Entities.AmazonWarehouse() { Id = 17, WarehouseCode = "MDT1", Name = "Amazon.com.dedc", AddressLine = "2 Ames Drive", City = "Carlisle", State = context.States.Where(i => i.Id == 38).FirstOrDefault(), ZipCode = "17015" },

                new Entities.AmazonWarehouse() { Id = 18, WarehouseCode = "MDT2", Name = "Amazon.com.dedc LLC", AddressLine = "600 Principio Parkway west", City = "North East", State = context.States.Where(i => i.Id == 20).FirstOrDefault(), ZipCode = "21901-2914" },

                new Entities.AmazonWarehouse() { Id = 19, WarehouseCode = "MKE1", Name = "Amazon.com.dedc LLC", AddressLine = "3501 120th Ave", City = "Kenosha", State = context.States.Where(i => i.Id == 49).FirstOrDefault(), ZipCode = "53144" },

                new Entities.AmazonWarehouse() { Id = 20, WarehouseCode = "ONT6", Name = "Golden State FC LLC", AddressLine = "24208 San Michele Road", City = "Moreno Valley", State = context.States.Where(i => i.Id == 5).FirstOrDefault(), ZipCode = "92551" },

                new Entities.AmazonWarehouse() { Id = 21, WarehouseCode = "PHX3", Name = "Amazon.com", AddressLine = "6835 West Buckeye Road", City = "Phoenix", State = context.States.Where(i => i.Id == 3).FirstOrDefault(), ZipCode = "85043" },

                new Entities.AmazonWarehouse() { Id = 22, WarehouseCode = "PHX5", Name = "Amazon.com.azdc, Inc", AddressLine = "16920 W. Commerce Dr", City = "Goodyear", State = context.States.Where(i => i.Id == 3).FirstOrDefault(), ZipCode = "85338" },

                new Entities.AmazonWarehouse() { Id = 23, WarehouseCode = "PHX7", Name = "Amazon.com.azdc, LLC", AddressLine = "800 N 7th Ave", City = "Phoenix", State = context.States.Where(i => i.Id == 3).FirstOrDefault(), ZipCode = "85043-2101" },

                new Entities.AmazonWarehouse() { Id = 24, WarehouseCode = "RIC1", Name = "Amazon.com.kydc LLC", AddressLine = "5000 COMMERCE WAY", City = "Petersburg", State = context.States.Where(i => i.Id == 46).FirstOrDefault(), ZipCode = "23803" },

                new Entities.AmazonWarehouse() { Id = 25, WarehouseCode = "SAT1", Name = "Amazon.com.kydc LLC", AddressLine = "6000 Enterprise Avenue", City = "Schertz", State = context.States.Where(i => i.Id == 43).FirstOrDefault(), ZipCode = "78154-1461" },

                new Entities.AmazonWarehouse() { Id = 26, WarehouseCode = "SDF1", Name = "Amazon.com", AddressLine = "1050 South Columbia Ave", City = "Campbellsville", State = context.States.Where(i => i.Id == 17).FirstOrDefault(), ZipCode = "42718" },

                new Entities.AmazonWarehouse() { Id = 27, WarehouseCode = "SDF4", Name = "Amazon.com.kydc LLC", AddressLine = "376 Zappos.com Blvd", City = "Shpepherdsville", State = context.States.Where(i => i.Id == 17).FirstOrDefault(), ZipCode = "40165" },

                new Entities.AmazonWarehouse() { Id = 28, WarehouseCode = "SDF8", Name = "Amazon.com.indc LLC", AddressLine = "900 Patrol Rd", City = "Jeffersonville", State = context.States.Where(i => i.Id == 14).FirstOrDefault(), ZipCode = "47130" }
                );

            //seed the States Table with all 50 US states.
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
