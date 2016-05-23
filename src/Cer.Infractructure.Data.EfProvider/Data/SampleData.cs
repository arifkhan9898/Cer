using System;
using System.Collections.Generic;
using System.Linq;
using Cer.Core.Enum;
using Cer.Core.Models;

namespace Cer.Infrastructure.Data.EfProvider.Data
{
    public class SampleData
    {
        public List<Equipment> Equipments { get; private set; }
        public List<CartEquipment> CartEquipments { get; private set; }
        public List<Cart> Carts { get; private set; }
        public List<User> Users { get; private set; }

        public SampleData()
        {
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

            Equipments = new[]
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
            }.ToList();
            Users = new[]
            {
                new User
                {
                    Id = 1,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    NickName = "Miguel de Cervantes"
                }
            }.ToList();
            Carts = new[]
            {
                new Cart
                {
                    Id = 1,
                    User = Users.First(),
                    AddedDate = moments[0],
                    ModifiedDate = moments[0]
                }
            }.ToList();
            CartEquipments = new[]
            {
                new CartEquipment
                {
                    Id = 1,
                    Cart = Carts[0],
                    Equipment = Equipments[1],
                    RentState = RentState.Running,
                    AddedDate = moments[0],
                    ModifiedDate = moments[0],
                    RentDurationDays = 4
                }
            }.ToList();
        }



    }
}
