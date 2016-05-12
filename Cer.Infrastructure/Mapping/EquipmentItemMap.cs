using System.Data.Entity.ModelConfiguration;
using Cer.Core.Models;

namespace Cer.Infrastructure.Mapping
{
    public class EquipmentItemMap : EntityTypeConfiguration<EquipmentItem>
    {
        public EquipmentItemMap()
        {        
            Property(t => t.ItemType).IsRequired();
            Property(t => t.ItemName).IsRequired();
        }
    }
}