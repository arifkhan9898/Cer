namespace Cer.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentEquipmentItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EquipmentItem", "RentItem_RentItemId", "dbo.RentItem");
            DropIndex("dbo.EquipmentItem", new[] { "RentItem_RentItemId" });
            CreateTable(
                "dbo.RentEquipmentItem",
                c => new
                    {
                        RentEquipmentItemId = c.Int(nullable: false, identity: true),
                        RentItemId = c.Int(nullable: false),
                        EquipmentItemId = c.Int(nullable: false),
                        Returned = c.DateTime(),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RentEquipmentItemId)
                .ForeignKey("dbo.EquipmentItem", t => t.EquipmentItemId, cascadeDelete: true)
                .ForeignKey("dbo.RentItem", t => t.RentItemId, cascadeDelete: true)
                .Index(t => t.RentItemId)
                .Index(t => t.EquipmentItemId);
            
            DropColumn("dbo.EquipmentItem", "ItemId");
            DropColumn("dbo.EquipmentItem", "ItemLanguage");
            DropColumn("dbo.EquipmentItem", "RentItem_RentItemId");
            DropColumn("dbo.RentItem", "Returned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RentItem", "Returned", c => c.DateTime());
            AddColumn("dbo.EquipmentItem", "RentItem_RentItemId", c => c.Int());
            AddColumn("dbo.EquipmentItem", "ItemLanguage", c => c.String());
            AddColumn("dbo.EquipmentItem", "ItemId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RentEquipmentItem", "RentItemId", "dbo.RentItem");
            DropForeignKey("dbo.RentEquipmentItem", "EquipmentItemId", "dbo.EquipmentItem");
            DropIndex("dbo.RentEquipmentItem", new[] { "EquipmentItemId" });
            DropIndex("dbo.RentEquipmentItem", new[] { "RentItemId" });
            DropTable("dbo.RentEquipmentItem");
            CreateIndex("dbo.EquipmentItem", "RentItem_RentItemId");
            AddForeignKey("dbo.EquipmentItem", "RentItem_RentItemId", "dbo.RentItem", "RentItemId");
        }
    }
}
