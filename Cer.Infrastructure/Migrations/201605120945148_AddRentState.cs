namespace Cer.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentState",
                c => new
                    {
                        RentStateId = c.Int(nullable: false, identity: true),
                        State = c.String(),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RentStateId);
            
            AddColumn("dbo.RentEquipmentItem", "ReturnDate", c => c.DateTime());
            AddColumn("dbo.RentEquipmentItem", "RentStateLastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RentEquipmentItem", "RentState_RentStateId", c => c.Int());
            CreateIndex("dbo.RentEquipmentItem", "RentState_RentStateId");
            AddForeignKey("dbo.RentEquipmentItem", "RentState_RentStateId", "dbo.RentState", "RentStateId");
            DropColumn("dbo.RentEquipmentItem", "Returned");
            DropColumn("dbo.RentItem", "Borrowed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RentItem", "Borrowed", c => c.DateTime(nullable: false));
            AddColumn("dbo.RentEquipmentItem", "Returned", c => c.DateTime());
            DropForeignKey("dbo.RentEquipmentItem", "RentState_RentStateId", "dbo.RentState");
            DropIndex("dbo.RentEquipmentItem", new[] { "RentState_RentStateId" });
            DropColumn("dbo.RentEquipmentItem", "RentState_RentStateId");
            DropColumn("dbo.RentEquipmentItem", "RentStateLastUpdate");
            DropColumn("dbo.RentEquipmentItem", "ReturnDate");
            DropTable("dbo.RentState");
        }
    }
}
