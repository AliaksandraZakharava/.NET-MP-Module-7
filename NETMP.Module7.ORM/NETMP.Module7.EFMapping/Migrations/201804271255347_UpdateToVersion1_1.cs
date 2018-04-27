using System.Data.Entity.Migrations;

namespace NETMP.Module7.EFMapping.Migrations
{
    public partial class UpdateToVersion1_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardId = c.Int(nullable: false, identity: true),
                        CardHolder = c.String(maxLength: 50),
                        ValidThru = c.DateTime(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        BankAddress = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.CreditCardId)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.CreditCards", new[] { "EmployeeID" });
            DropTable("dbo.CreditCards");
        }
    }
}
