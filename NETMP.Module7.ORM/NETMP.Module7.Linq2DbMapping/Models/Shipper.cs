using LinqToDB.Mapping;

namespace NETMP.Module7.Linq2DbMapping.Models
{
    [Table("Shippers")]
    public class Shipper
    {
        [Column("ShipperID"), PrimaryKey, Identity]
        public int Id { get; set; }

        [Column, NotNull]
        public string CompanyName { get; set; }

        [Column]
        public string Phone { get; set; }
    }
}
