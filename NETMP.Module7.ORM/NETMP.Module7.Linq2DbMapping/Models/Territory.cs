using LinqToDB.Mapping;

namespace NETMP.Module7.Linq2DbMapping.Models
{
    [Table("Territories")]
    public class Territory
    {
        [Column("TerritoryID"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column, NotNull]
        public string TerritoryDescription { get; set; }

        [Column("RegionID")]
        public int RegionId { get; set; }

        [Association(ThisKey = "RegionId", OtherKey = "Id")]
        public Region Region { get; set; }
    }
}
