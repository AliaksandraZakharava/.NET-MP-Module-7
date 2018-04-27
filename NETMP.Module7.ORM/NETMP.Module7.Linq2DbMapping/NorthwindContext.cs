using LinqToDB;
using LinqToDB.Data;
using NETMP.Module7.Linq2DbMapping.Models;

namespace NETMP.Module7.Linq2DbMapping
{
    public class NorthwindContext : DataConnection
    {
        public NorthwindContext() : base("Northwind")
        { }

        public ITable<Category> Categories => GetTable<Category>();

        public ITable<Customer> Customers => GetTable<Customer>();

        public ITable<CustomerDemographic> CustomerDemographics => GetTable<CustomerDemographic>();

        public ITable<Employee> Employees => GetTable<Employee>();

        public ITable<Order> Orders => GetTable<Order>();

        public ITable<OrderDetail> OrderDetails => GetTable<OrderDetail>();

        public ITable<Product> Products => GetTable<Product>();

        public ITable<Region> Regions => GetTable<Region>();

        public ITable<Shipper> Shippers => GetTable<Shipper>();

        public ITable<Supplier> Suppliers => GetTable<Supplier>();

        public ITable<Territory> Territories => GetTable<Territory>();
    }
}
