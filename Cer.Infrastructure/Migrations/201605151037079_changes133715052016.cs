namespace Cer.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes133715052016 : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EquipmentDtoes");
        }
    }
}
