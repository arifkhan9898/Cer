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
            //  This method will be called after migrating to the latest version.

            var moments = new[]
            {
                new DateTime(2010, 10, 10, 12, 0, 1),
                new DateTime(2010, 10, 12, 14, 0, 1)
            };
            var equipmentItems = new[]
            {
                new EquipmentItem
                {
                    Id = 1,
                    ItemType = 0,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    ItemName = "Caterpillar bulldozer"
                },
                new EquipmentItem
                {
                    Id = 2,
                    ItemType = 1,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    ItemName = "KamAZ truck"
                },
                new EquipmentItem
                {
                    Id = 3,
                    ItemType = 0,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    ItemName = "Komatsu crane"
                },
                new EquipmentItem
                {
                    Id = 4,
                    ItemType = 1,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    ItemName = "Volvo steamroller"
                },
                new EquipmentItem
                {
                    Id = 5,
                    ItemType = 2,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    ItemName = "Bosch jackhammer"
                }
            };
            var rentStates = new[]
            {
                new RentState {Id = 1, AddedDate = moments[0], ModifiedDate = moments[0], State = "Completed"},
                new RentState {Id = 2, AddedDate = moments[0], ModifiedDate = moments[0], State = "In progress"},
                new RentState {Id = 3, AddedDate = moments[0], ModifiedDate = moments[0], State = "Overdue"}
            };
            var rentItems = new[]
            {
                new RentCart
                {
                    Id = 1,
                    CustomerNickname = "Miguel de Cervantes",
                    RentDurationDays = 2,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0]
                }
            };
            var rentEquipmentItems = new[]
            {
                new RentEquipmentItem
                {
                    Id = 1,
                    RentCart = rentItems[0],
                    EquipmentItem = equipmentItems[1],
                    RentState = rentStates[1],
                    AddedDate = moments[0],
                    ModifiedDate = moments[0]
                }
            };
            context.Set<EquipmentItem>().AddOrUpdate(x => x.Id, equipmentItems);
            context.Set<RentState>().AddOrUpdate(x => x.Id, rentStates);
            context.Set<RentCart>().AddOrUpdate(x => x.Id, rentItems);
            context.Set<RentEquipmentItem>().AddOrUpdate(x => x.Id, rentEquipmentItems);
        }
    }
}