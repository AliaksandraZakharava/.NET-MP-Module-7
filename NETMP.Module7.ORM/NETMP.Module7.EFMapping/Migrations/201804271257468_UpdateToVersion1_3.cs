using System.Data.Entity.Migrations;

namespace NETMP.Module7.EFMapping.Migrations
{
    public partial class UpdateToVersion1_3 : DbMigration
    {
        public override void Up()
        {
            RenameTable("Regions", "Region");
            AddColumn("dbo.Customers", "FoundationDate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            RenameTable("Region", "Regions");
            DropColumn("dbo.Customers", "FoundationDate");
        }
    }
}
