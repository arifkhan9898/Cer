using Cer.Core.DataTransferObjects;
using Cer.Core.Models;

namespace Cer.Mapper
{
    public static class MapExtensions
    {
        public static EquipmentDto AsDto(this Equipment equipment)
        {
            return new EquipmentDto
            {
                Id = equipment.Id,
                ItemName = equipment.ItemName,
                ItemType = equipment.ItemType
            };
        }
    }
}
