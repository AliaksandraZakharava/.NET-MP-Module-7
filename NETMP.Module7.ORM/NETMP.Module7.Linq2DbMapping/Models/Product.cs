using LinqToDB;
using LinqToDB.Mapping;

namespace NETMP.Module7.Linq2DbMapping.Models
{
    [Table("Products")]
    public class Product
    {
        [Column("ProductID"), PrimaryKey, Identity]
        public int Id { get; set; }

        [Column, NotNull]
        public string ProductName { get; set; }

        [Column("SupplierID")]
        public int? SupplierId { get; set; }

        [Column("CategoryID")]
        public int? CategoryId { get; set; }

        [Column]
        public string QuantityPerUnit { get; set; }

        [Column(DataType = DataType.Money)]
        public decimal? UnitPrice { get; set; }

        [Column]
        public short? UnitsInStock { get; set; }

        [Column]
        public short? UnitsOnOrder { get; set; }

        [Column]
        public short? ReorderLevel { get; set; }

        [Column]
        public bool Discontinued { get; set; }

        [Association(ThisKey = "SupplierId", OtherKey = "Id")]
        public Supplier Supplier { get; set; }

        [Association(ThisKey = "CategoryId", OtherKey = "Id")]
        public Category Category { get; set; }
    }
}
