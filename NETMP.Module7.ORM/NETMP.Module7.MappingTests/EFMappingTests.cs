using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NETMP.Module7.EFMapping;
using NETMP.Module7.MappingTests.TestHelpers;

namespace NETMP.Module7.MappingTests
{
    [TestClass]
    public class EFMappingTests
    {
        private readonly NorthwindContext _context;

        public EFMappingTests()
        {
            _context = new NorthwindContext();
        }

        [TestMethod]
        public void Task1_SelectOrdersForOneCategory()
        {
            var categoryId = 8;

            var orders = _context.Orders.Where(order => order.OrderDetails.Select(orderDetail => orderDetail.Product.CategoryID).Contains(categoryId))
                                        .Select(order => new OrderProductsInfo
                                        {
                                            OrderId = order.OrderID,
                                            OrderDetails = order.OrderDetails,
                                            CustomerName = _context.Customers.FirstOrDefault(customer => customer.CustomerID == order.CustomerID).CompanyName,
                                            ProductNames = _context.OrderDetails.Where(od => od.OrderID == order.OrderID).Select(od => od.Product.ProductName)
                                        })
                                        .ToList();

            orders.ForEach(Display.OrderProductsInfo);
        }
    }
}
