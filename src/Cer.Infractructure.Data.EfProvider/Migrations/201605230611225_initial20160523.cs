namespace Cer.Infrastructure.Data.EfProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial20160523 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentDtoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EquipmentName = c.String(),
                        EquipmentType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EquipmentType = c.Int(nullable: false),
                        EquipmentName = c.String(nullable: false),
                        EquipmentAmountId = c.Int(nullable: false),
                        EquipmentTypeId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Ip = c.String(),
                        EquipmentAmount_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EquipmentAmounts", t => t.EquipmentAmount_Id)
                .Index(t => t.EquipmentAmount_Id);
            
            CreateTable(
                "dbo.CartEquipments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                        ReturnDate = c.DateTime(),
                        RentState = c.Int(nullable: false),
                        RentDurationDays = c.Int(nullable: false),
                        RentStateId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Ip = c.String(),
                        Cart_Id = c.Long(),
                        Equipment_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .Index(t => t.Cart_Id)
                .Index(t => t.Equipment_Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Ip = c.String(),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NickName = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EquipmentAmounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipments", "EquipmentAmount_Id", "dbo.EquipmentAmounts");
            DropForeignKey("dbo.CartEquipments", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.Carts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CartEquipments", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Carts", new[] { "User_Id" });
            DropIndex("dbo.CartEquipments", new[] { "Equipment_Id" });
            DropIndex("dbo.CartEquipments", new[] { "Cart_Id" });
            DropIndex("dbo.Equipments", new[] { "EquipmentAmount_Id" });
            DropTable("dbo.EquipmentAmounts");
            DropTable("dbo.Users");
            DropTable("dbo.Carts");
            DropTable("dbo.CartEquipments");
            DropTable("dbo.Equipments");
            DropTable("dbo.EquipmentDtoes");
        }
    }
}
