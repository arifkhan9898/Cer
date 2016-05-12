using System.Collections.Generic;
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
            var moments = new[]
            {
                new DateTime(2010, 10, 10, 12, 0, 1),
                new DateTime(2010, 10, 12, 14, 0, 1)
            };
            var customers = new[] {
                new Customer { CustomerId = 1, Nickname = "Jane Austen"},
                new Customer { CustomerId = 2, Nickname = "Charles Dickens" },
                new Customer { CustomerId = 3, Nickname = "Miguel de Cervantes" }
            };
            var equipmentItems = new[] {
                new EquipmentItem { EquipmentItemId = 1, ItemType = 0, ItemName = "Caterpillar bulldozer" },
                new EquipmentItem { EquipmentItemId = 2, ItemType = 1, ItemName = "KamAZ truck"},
                new EquipmentItem { EquipmentItemId = 3, ItemType = 0, ItemName = "Komatsu crane" },
                new EquipmentItem { EquipmentItemId = 4, ItemType = 1, ItemName = "Volvo steamroller" },
                new EquipmentItem { EquipmentItemId = 5, ItemType = 2, ItemName = "Bosch jackhammer" }
            };
            var rentStates = new[] {
                new RentState { RentStateId = 1, State = "Completed" },
                new RentState { RentStateId = 2, State = "In progress" },
                new RentState { RentStateId = 3, State = "Overdue" }
            };
            var rentItems = new[] {
                new RentItem
                {
                    RentItemId =  1,
                    Customer = customers[1],
                    RentDurationDays = 2,
                    RentDateAdded = moments[0]
                }
            };
            var rentEquipmentItems = new[] {
                new RentEquipmentItem
                {
                    RentEquipmentItemId = 1,
                    RentItem = rentItems[0],
                    EquipmentItem = equipmentItems[1],
                    RentState = rentStates[1],
                    RentStateLastUpdate = moments[0]
                }
            };
            context.Customers.AddOrUpdate(x => x.CustomerId, customers);
            context.EquipmentItems.AddOrUpdate(x => x.EquipmentItemId, equipmentItems);
            context.RentStates.AddOrUpdate(x => x.RentStateId, rentStates);
            context.RentItems.AddOrUpdate(x => x.RentItemId, rentItems);
            context.RentEquipmentItems.AddOrUpdate(x => x.RentEquipmentItemId, rentEquipmentItems);
        }
    }
}
