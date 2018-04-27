using NETMP.Module7.EFMapping.Models;
using System.Data.Entity.Migrations;

namespace NETMP.Module7.EFMapping.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<NorthwindContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NorthwindContext context)
        {
            context.Categories.AddOrUpdate(category => category.CategoryID,
                new Category { CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
                new Category { CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
                new Category { CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" },
                new Category { CategoryName = "Dairy Products", Description = "Cheeses" },
                new Category { CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" });

            context.Region.AddOrUpdate(region => region.RegionID,
                new Region { RegionID = 1, RegionDescription = "Eastern" },
                new Region { RegionID = 2, RegionDescription = "Western" },
                new Region { RegionID = 3, RegionDescription = "Northern" },
                new Region { RegionID = 4, RegionDescription = "Southern" });

            context.Territories.AddOrUpdate(territory => territory.TerritoryID,
                new Territory { TerritoryID = "01581", TerritoryDescription = "Westboro", RegionID = 1 },
                new Territory { TerritoryID = "01730", TerritoryDescription = "Bedford", RegionID = 1 },
                new Territory { TerritoryID = "01833", TerritoryDescription = "Georgetow", RegionID = 1 },
                new Territory { TerritoryID = "02116", TerritoryDescription = "Boston", RegionID = 1 },
                new Territory { TerritoryID = "02139", TerritoryDescription = "Cambridge", RegionID = 1 });
        }
    }
}
