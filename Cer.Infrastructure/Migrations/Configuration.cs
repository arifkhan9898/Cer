using Cer.Core.Models;

namespace Cer.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cer.Infrastructure.CerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Cer.Infrastructure.CerDbContext context)
        {
            var customers = new[] {
                new Customer { CustomerId = 1, Nickname = "Jane Austen"},
                new Customer { CustomerId = 2, Nickname = "Charles Dickens" },
                new Customer { CustomerId = 3, Nickname = "Miguel de Cervantes" }
            };
            context.Customers.AddOrUpdate(x => x.CustomerId,
                customers[0],
                customers[1],
                customers[2]
            );
            context.EquipmentItems.AddOrUpdate(x => x.EquipmentItemId,
                new EquipmentItem { EquipmentItemId = 1, ItemId = 1, ItemLanguage = "en", ItemName = "Caterpillar bulldozer", ItemType = 0 },
                new EquipmentItem { EquipmentItemId = 2, ItemId = 1, ItemLanguage = "et", ItemName = "Caterpillar bulldozer", ItemType = 0 },
                new EquipmentItem { EquipmentItemId = 3, ItemId = 2, ItemLanguage = "en", ItemName = "KamAZ truck", ItemType = 1},
                new EquipmentItem { EquipmentItemId = 4, ItemId = 2, ItemLanguage = "et", ItemName = "KamAZ truck", ItemType = 1 },
                new EquipmentItem { EquipmentItemId = 5, ItemId = 3, ItemLanguage = "en", ItemName = "Komatsu crane", ItemType = 0 },
                new EquipmentItem { EquipmentItemId = 6, ItemId = 3, ItemLanguage = "et", ItemName = "Komatsu crane", ItemType = 0 },
                new EquipmentItem { EquipmentItemId = 7, ItemId = 4, ItemLanguage = "en", ItemName = "Volvo steamroller", ItemType = 1 },
                new EquipmentItem { EquipmentItemId = 8, ItemId = 4, ItemLanguage = "et", ItemName = "Volvo steamroller", ItemType = 1 },
                new EquipmentItem { EquipmentItemId = 9, ItemId = 5, ItemLanguage = "en", ItemName = "Volvo steamroller", ItemType = 2 },
                new EquipmentItem { EquipmentItemId = 10, ItemId = 5, ItemLanguage = "et", ItemName = "Volvo steamroller", ItemType = 2 }
            );
        }
    }
}
