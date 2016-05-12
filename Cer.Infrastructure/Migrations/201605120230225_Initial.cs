namespace Cer.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Nickname = c.String(),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.EquipmentItem",
                c => new
                    {
                        EquipmentItemId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        ItemType = c.Int(nullable: false),
                        ItemLanguage = c.String(),
                        ItemName = c.String(),
                        EntityId = c.Int(nullable: false),
                        RentItem_RentItemId = c.Int(),
                    })
                .PrimaryKey(t => t.EquipmentItemId)
                .ForeignKey("dbo.RentItem", t => t.RentItem_RentItemId)
                .Index(t => t.RentItem_RentItemId);
            
            CreateTable(
                "dbo.RentItem",
                c => new
                    {
                        RentItemId = c.Int(nullable: false, identity: true),
                        Borrowed = c.DateTime(nullable: false),
                        Returned = c.DateTime(),
                        RentDurationDays = c.Int(nullable: false),
                        RentDateAdded = c.DateTime(nullable: false),
                        EntityId = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.RentItemId)
                .ForeignKey("dbo.Customer", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquipmentItem", "RentItem_RentItemId", "dbo.RentItem");
            DropForeignKey("dbo.RentItem", "Customer_CustomerId", "dbo.Customer");
            DropIndex("dbo.RentItem", new[] { "Customer_CustomerId" });
            DropIndex("dbo.EquipmentItem", new[] { "RentItem_RentItemId" });
            DropTable("dbo.RentItem");
            DropTable("dbo.EquipmentItem");
            DropTable("dbo.Customer");
        }
    }
}
