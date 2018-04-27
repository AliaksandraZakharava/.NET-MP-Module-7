using System.Linq;
using LinqToDB;
using LinqToDB.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NETMP.Module7.Linq2DbMapping;
using NETMP.Module7.Linq2DbMapping.Models;
using NETMP.Module7.MappingTests.TestHelpers;

namespace NETMP.Module7.MappingTests
{
    [TestClass]
    public class Linq2DbMappingTests
    {
        private readonly NorthwindContext _context;

        public Linq2DbMappingTests()
        {
            Configuration.Linq.AllowMultipleQuery = true;

            _context = new NorthwindContext();
        }

        [TestMethod]
        public void Task2_GetProductsWithCategoryAndSupplier()
        {
            var products = _context.Products.LoadWith(request => request.Category)
                                            .LoadWith(request => request.Supplier)
                                            .ToList();

            products.ForEach(Display.ProductInfo);
        }

        // Employees table has no foreign key for Region table
        // The only foreign key is reporting to Employee
        [TestMethod]
        public void Task2_GetEmployeesWithTheirManager()
        {
            var employees = _context.Employees.LoadWith(request => request.Reporter)
                                              .ToList();

            employees.ForEach(Display.EmploeeReportingInfo);
        }

        [TestMethod]
        public void Task2_GetEmployeesPerManagerStatistics()
        {
            var statistics = _context.Employees.LoadWith(request => request.Reporter)
                                               .GroupBy(employee => employee.Reporter)
                                               .Select(data => new ManagerEmployeesStatistics
                                               {
                                                    Manager = $"{data.Key.FirstName} {data.Key.LastName}",
                                                    ReportersNumber = data.Count()
                                               })
                                                .ToList();

            statistics.ForEach(Display.ManagerEmployeesStatistics);
        }

        [TestMethod]
        public void Task2_GetShippersPerEmployeeStatistics()
        {
            var statistics = _context.Orders.LoadWith(request => request.Employee)
                                            .LoadWith(request => request.Shipper)
                                            .Select(data => new { Employee = data.Employee.LastName, ShipperName = data.Shipper.CompanyName})
                                            .GroupBy(data => data.Employee)
                                            .Select(group => new EmployeeShippersInfo
                                            {
                                                 Employee = group.Key,
                                                 Shippers = group.Select(item => item.ShipperName).Distinct().OrderBy(item => item)
                                             })
                                            .OrderBy(item => item.Employee)
                                            .ToList();

            statistics.ForEach(Display.EmployeeShippersInfo);
        }

        [TestMethod]
        public void Task3_AddNewEmployeeWithReporter()
        {
            Display.TotalCountInsert(_context.Employees.Count());

            _context.Insert(TestData.Employee);

            Display.TotalCountInsert(_context.Employees.Count(), false);
        }

        [TestMethod]
        public void Task3_ChangeProductsCategory()
        {
            Display.TotalCountUpdate(_context.Products.Count(product => product.CategoryId == 2));

            var products = _context.Products.Where(product => product.CategoryId == 1).ToList();

            products.ForEach(product => _context.Products.Where(pr => pr.Id == product.Id)
                                                         .Set(pr => pr.CategoryId, 2)
                                                         .Update());

            Display.TotalCountUpdate(_context.Products.Count(product => product.CategoryId == 2), true);
        }

        [TestMethod]
        public void Task3_AddListOfProductsWithNewOrExistingSuppliersAndCategories()
        {
            Display.DataForAddListOfProducts(_context.Products.Count(), _context.Suppliers.Count(), _context.Categories.Count());

            TestData.Products.ForEach(product =>
            {
                var categoryId = _context.Categories.Any(category => category.CategoryName == product.Category.CategoryName)
                                ? _context.Categories.Single(category => category.CategoryName == product.Category.CategoryName).Id
                                : _context.InsertWithInt32Identity(product.Category);

                var supplierId = _context.Suppliers.Any(supplier => supplier.CompanyName == product.Supplier.CompanyName)
                                ? _context.Suppliers.Single(supplier => supplier.CompanyName == product.Supplier.CompanyName).Id
                                : _context.InsertWithInt32Identity(product.Supplier);

                _context.Products.Insert(() => new Product
                {
                    ProductName = product.ProductName,
                    CategoryId = categoryId,
                    SupplierId = supplierId
                });
            });

            Display.DataForAddListOfProducts(_context.Products.Count(), _context.Suppliers.Count(), _context.Categories.Count(), true);
        }

        [TestMethod]
        public void Task3_ChangeProductsInNoShippedOrders()
        {
            var updatingOrderId = 11008;

            Display.DataForChangeProductsUpdate(_context.OrderDetails.Where(order => order.OrderId == updatingOrderId));

            var notShippedOrdersIds = _context.Orders.Where(order => order.ShippedDate == null).Select(order => order.Id).ToList();

            var orderDetailsForNotShippedOrders = _context.OrderDetails.LoadWith(request => request.Product)
                                                                       .Where(orderDetail => notShippedOrdersIds.Contains(orderDetail.OrderId)).Take(10)
                                                                       .ToList();

            orderDetailsForNotShippedOrders.ForEach(order =>
            {
                var orderDetailsProductIds = _context.OrderDetails.Where(orderDetail => orderDetail.OrderId == order.OrderId).Select(o => o.ProductId).ToList();

                _context.OrderDetails.Where(orderDetail => orderDetail.OrderId == order.OrderId && orderDetail.ProductId == order.ProductId)
                    .Set(orderDetail => orderDetail.ProductId, _context.Products.First(product => product.CategoryId == order.Product.CategoryId &&
                                                                                                  !orderDetailsProductIds.Contains(product.CategoryId.Value)).Id)
                    .Set(orderDetail => orderDetail.UnitPrice, _context.Products.Single(product => product.Id == order.ProductId).UnitPrice.Value)
                    .Update();
            });

            Display.DataForChangeProductsUpdate(_context.OrderDetails.Where(order => order.OrderId == updatingOrderId));
        }
    }
}
