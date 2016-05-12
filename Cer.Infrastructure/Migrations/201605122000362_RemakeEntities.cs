namespace Cer.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemakeEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ItemType = c.Int(nullable: false),
                        ItemName = c.String(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentEquipmentItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RentItemId = c.Int(nullable: false),
                        EquipmentItemId = c.Int(nullable: false),
                        ReturnDate = c.DateTime(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Ip = c.String(),
                        EquipmentItem_Id = c.Long(),
                        RentCart_Id = c.Long(),
                        RentState_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EquipmentItems", t => t.EquipmentItem_Id)
                .ForeignKey("dbo.RentCarts", t => t.RentCart_Id)
                .ForeignKey("dbo.RentStates", t => t.RentState_Id)
                .Index(t => t.EquipmentItem_Id)
                .Index(t => t.RentCart_Id)
                .Index(t => t.RentState_Id);
            
            CreateTable(
                "dbo.RentCarts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerNickname = c.String(),
                        RentDurationDays = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentStates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        State = c.String(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentEquipmentItems", "RentState_Id", "dbo.RentStates");
            DropForeignKey("dbo.RentEquipmentItems", "RentCart_Id", "dbo.RentCarts");
            DropForeignKey("dbo.RentEquipmentItems", "EquipmentItem_Id", "dbo.EquipmentItems");
            DropIndex("dbo.RentEquipmentItems", new[] { "RentState_Id" });
            DropIndex("dbo.RentEquipmentItems", new[] { "RentCart_Id" });
            DropIndex("dbo.RentEquipmentItems", new[] { "EquipmentItem_Id" });
            DropTable("dbo.RentStates");
            DropTable("dbo.RentCarts");
            DropTable("dbo.RentEquipmentItems");
            DropTable("dbo.EquipmentItems");
        }
    }
}
