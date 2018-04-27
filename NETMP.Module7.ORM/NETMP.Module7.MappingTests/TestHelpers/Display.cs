using System;
using System.Collections.Generic;
using System.Linq;
using NETMP.Module7.Linq2DbMapping.Models;

namespace NETMP.Module7.MappingTests.TestHelpers
{
    public static class Display
    {
        public static void ProductInfo(Product product)
        {
            Console.WriteLine($"- {product.ProductName} (category: {product.Category.CategoryName}, supplier: {product.Supplier.CompanyName})");
        }

        public static void EmploeeReportingInfo(Employee employee)
        {
            var reporter = employee.Reporter == null ? "no one" : $"{employee.Reporter.FirstName} {employee.Reporter.LastName}";

            Console.WriteLine($"{employee.FirstName} {employee.LastName} reports to {reporter}");
        }

        public static void ManagerEmployeesStatistics(ManagerEmployeesStatistics item)
        {
            Console.WriteLine(item.Manager.Trim() == string.Empty
                              ? $"{item.ReportersNumber} employee(s) has(ve) no manager to report."
                              : $"{item.Manager} has {item.ReportersNumber} reporters.");
        }

        public static void EmployeeShippersInfo(EmployeeShippersInfo item)
        {
            Console.WriteLine($"{item.Employee} has worked with:");

            item.Shippers.ToList().ForEach(shipper => Console.WriteLine($"- {shipper}"));
        }

        public static void TotalCountInsert(int count, bool before = true)
        {
            var period = before ? "Before" : "After";

            Console.WriteLine($"{period} insert {count} items");
        }

        public static void TotalCountUpdate(int count, bool before = true)
        {
            var period = before ? "Before" : "After";

            Console.WriteLine($"{period} update {count} items in Category 2");
        }

        public static void DataForAddListOfProducts(int productsNumber, int categoriesNumber, int suppliersNumber, bool before = true)
        {
            var period = before ? "Before" : "After";

            Console.WriteLine($"{period} insert {productsNumber} items in Products");
            Console.WriteLine($"{period} insert {categoriesNumber} items in Suppliers");
            Console.WriteLine($"{period} insert {suppliersNumber} items in Categories {Environment.NewLine}");
        }

        public static void OrderDetailsInfo(OrderDetail order)
        {
            Console.WriteLine($"OrderId {order.OrderId} - product id {order.ProductId} {order.UnitPrice}");
        }

        public static void DataForChangeProductsUpdate(IEnumerable<OrderDetail> orderDetails, bool before = true)
        {
            var period = before ? "Before" : "After";

            Console.WriteLine($"{period} update:");

            orderDetails.ToList().ForEach(OrderDetailsInfo);
        }

        public static void OrderProductsInfo(OrderProductsInfo info)
        {
            Console.WriteLine($"Order {info.OrderId}");
            Console.WriteLine($"Customer {info.CustomerName}");

            Console.WriteLine("OrderDetails:");
            info.OrderDetails.ToList().ForEach(od => Console.WriteLine($"- category id: {od.Product.CategoryID}, quantity: {od.Quantity}"));

            Console.WriteLine("Products:");
            info.ProductNames.ToList().ForEach(product => Console.WriteLine($"- {product}"));

            Console.WriteLine();
        }
    }
}
