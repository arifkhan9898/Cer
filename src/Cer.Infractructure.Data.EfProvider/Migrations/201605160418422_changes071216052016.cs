using System.Data.Entity.Migrations;

namespace Cer.Infrastructure.Data.EfProvider.Migrations
{
    public partial class changes071216052016 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartEquipments", "RentDurationDays", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartEquipments", "RentDurationDays");
        }
    }
}
