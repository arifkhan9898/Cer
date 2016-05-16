namespace Cer.Infrastructure.Migrations
{
    using Core.Enum;
    using Core.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cer.Infrastructure.Contextes.CerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contextes.CerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var moments = new[]
            {
                new DateTime(2010, 10, 10, 12, 0, 1),
                new DateTime(2010, 10, 12, 14, 0, 1)
            };
            var amount = new EquipmentAmount
            {
                Id = 1,
                Amount = 1,
                AddedDate = moments[0],
                ModifiedDate = moments[0]
            };
            var equipmentItems = new[]
            {
                new Equipment
                {
                    Id = 1,
                    EquipmentType = EquipmentType.Heavy,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    EquipmentName = "Caterpillar bulldozer",
                    EquipmentAmount = amount
                },
                new Equipment
                {
                    Id = 2,
                    EquipmentType = EquipmentType.Regular,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    EquipmentName = "KamAZ truck"
                },
                new Equipment
                {
                    Id = 3,
                    EquipmentType = EquipmentType.Heavy,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    EquipmentName = "Komatsu crane",
                    EquipmentAmount = amount
                },
                new Equipment
                {
                    Id = 4,
                    EquipmentType = EquipmentType.Regular,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    EquipmentName = "Volvo steamroller",
                    EquipmentAmount = amount
                },
                new Equipment
                {
                    Id = 5,
                    EquipmentType = EquipmentType.Specialized,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    EquipmentName = "Bosch jackhammer",
                    EquipmentAmount = amount
                }
            };
            var user = new User
            {
                Id = 1,
                AddedDate = moments[0],
                ModifiedDate = moments[0],
                NickName = "Miguel de Cervantes"
            };
            var rentItems = new[]
            {
                new Cart
                {
                    Id = 1,
                    User = user,
                    RentDurationDays = 2,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0]
                }
            };
            var rentEquipmentItems = new[]
            {
                new CartEquipment
                {
                    Id = 1,
                    Cart = rentItems[0],
                    Equipment = equipmentItems[1],
                    RentState = RentState.Running,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    RentDurationDays = 4
                }
            };
            context.Set<User>().AddOrUpdate(x => x.Id, user);
            context.Set<Equipment>().AddOrUpdate(x => x.Id, equipmentItems);
            context.Set<Cart>().AddOrUpdate(x => x.Id, rentItems);
            context.Set<CartEquipment>().AddOrUpdate(x => x.Id, rentEquipmentItems);
        }
    }
}
