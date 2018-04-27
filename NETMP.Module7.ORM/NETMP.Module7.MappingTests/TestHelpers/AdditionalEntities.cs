using System.Collections.Generic;
using NETMP.Module7.Linq2DbMapping.Models;

namespace NETMP.Module7.MappingTests.TestHelpers
{
    public class ManagerEmployeesStatistics
    {
        public string Manager { get; set; }

        public int ReportersNumber { get; set; }
    }

    public class EmployeeShippersInfo
    {
        public string Employee { get; set; }

        public IEnumerable<string> Shippers { get; set; }
    }

    public class ProductInsertInfo
    {
        public string ProductName { get; set; }

        public Category Category { get; set; }

        public Supplier Supplier { get; set; }
    }

    public class OrderProductsInfo
    {
        public int OrderId { get; set; }

        public IEnumerable<EFMapping.Models.OrderDetail> OrderDetails { get; set; }

        public string CustomerName { get; set; }

        public IEnumerable<string> ProductNames { get; set; }
    }
}
