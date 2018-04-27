using LinqToDB.Mapping;

namespace NETMP.Module7.Linq2DbMapping.Models
{
    [Table]
    public class Region
    {
        [Column("RegionID"), PrimaryKey, Identity]
        public int Id { get; set; }

        [Column, NotNull]
        public string RegionDescription { get; set; }
    }
}
