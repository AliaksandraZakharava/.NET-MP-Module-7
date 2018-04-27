using System;
using LinqToDB;
using LinqToDB.Mapping;

namespace NETMP.Module7.Linq2DbMapping.Models
{
    [Table("Orders")]
    public class Order
    {
        [Column("OrderID"), PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("CustomerID"), NotNull]
        public string CustomerId { get; set; }

        [Column("EmployeeID"), NotNull]
        public int? EmployeeId { get; set; }

        [Column]
        public DateTime? OrderDate { get; set; }

        [Column]
        public DateTime? RequiredDate { get; set; }

        [Column]
        public DateTime? ShippedDate { get; set; }

        [Column]
        public int? ShipVia { get; set; }

        [Column(DataType = DataType.Money)]
        public decimal? Freight { get; set; }

        [Column]
        public string ShipName { get; set; }

        [Column]
        public string ShipAddress { get; set; }

        [Column]
        public string ShipCity { get; set; }

        [Column]
        public string ShipRegion { get; set; }

        [Column]
        public string ShipPostalCode { get; set; }

        [Column]
        public string ShipCountry { get; set; }

        [Association(ThisKey = "CustomerId", OtherKey = "Id")]
        public Customer Customer { get; set; }

        [Association(ThisKey = "EmployeeId", OtherKey = "Id")]
        public Employee Employee { get; set; }

        [Association(ThisKey = "ShipVia", OtherKey = "Id")]
        public Shipper Shipper { get; set; }
    }
}
