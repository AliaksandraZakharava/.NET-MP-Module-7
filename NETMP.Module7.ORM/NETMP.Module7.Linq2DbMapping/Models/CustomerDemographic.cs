using LinqToDB;
using LinqToDB.Mapping;

namespace NETMP.Module7.Linq2DbMapping.Models
{
    [Table("CustomerDemographics")]
    public class CustomerDemographic
    {
        [Column("CustomerTypeID"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(DataType = DataType.NText)]
        public string CustomerDesc { get; set; }
    }
}
