using LinqToDB;
using LinqToDB.Mapping;

namespace NETMP.Module7.Linq2DbMapping.Models
{
    [Table("Order Details")]
    public class OrderDetail
    {
        [Column("OrderID", PrimaryKeyOrder = 0), PrimaryKey]
        public int OrderId { get; set; }

        [Column("ProductID", PrimaryKeyOrder = 1), PrimaryKey]
        public int ProductId { get; set; }

        [Column(DataType = DataType.Money)]
        public decimal UnitPrice { get; set; }

        [Column]
        public short Quantity { get; set; }

        [Column]
        public float Discount { get; set; }

        [Association(ThisKey = "OrderId", OtherKey = "Id")]
        public Order Order { get; set; }

        [Association(ThisKey = "ProductId", OtherKey = "Id")]
        public Product Product { get; set; }
    }
}
