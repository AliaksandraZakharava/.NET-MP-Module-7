using LinqToDB;
using LinqToDB.Mapping;

namespace NETMP.Module7.Linq2DbMapping.Models
{
    [Table("Categories")]
    public class Category
    {
        [Column("CategoryId"), PrimaryKey, Identity]
        public int Id { get; set; }

        [Column, NotNull]
        public string CategoryName { get; set; }

        [Column(DataType = DataType.NText)]
        public string Description { get; set; }

        [Column(DataType = DataType.Image)]
        public byte[] Picture { get; set; }
    }
}
