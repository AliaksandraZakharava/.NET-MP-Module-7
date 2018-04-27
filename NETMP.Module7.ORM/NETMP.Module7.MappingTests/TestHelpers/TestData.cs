using System.Collections.Generic;
using NETMP.Module7.Linq2DbMapping.Models;

namespace NETMP.Module7.MappingTests.TestHelpers
{
    public static class TestData
    {
        public static Employee Employee = new Employee
        {
            FirstName = "Sasha",
            LastName = "Zakharava",
            Address = "Aliaksandra_Zakharava@epam.com",
            City = "Minsk",
            Country = "Belarus",
            ReportsTo = 2
        };

        public static Category NewCategory = new Category
        {
            CategoryName = "Green-stuff",
            Description = "Vegetables, fruits"
        };

        public static Category ExistingCategory = new Category
        {
            CategoryName = "Beverages"
        };

        public static Supplier NewSupplier = new Supplier
        {
            CompanyName = "Green garden",
            Country = "Belarus",
            City = "Minsk"
        };

        public static Supplier ExistingSupplier = new Supplier
        {
            CompanyName = "Exotic Liquids"
        };

        public static List<ProductInsertInfo> Products = new List<ProductInsertInfo>
        {
            new ProductInsertInfo {ProductName = "Eggplant", Category = NewCategory, Supplier = NewSupplier},
            new ProductInsertInfo {ProductName = "Orange juice", Category = ExistingCategory, Supplier = NewSupplier},
            new ProductInsertInfo {ProductName = "Pineapple", Category = NewCategory, Supplier = ExistingSupplier},
            new ProductInsertInfo {ProductName = "Mojito", Category = ExistingCategory, Supplier = ExistingSupplier}
        };
    }
}
