using System.Data.Entity.ModelConfiguration;
using Cer.Core.Models;

namespace Cer.Infrastructure.Data.EfProvider.Mapping
{
    public class EquipmentMap : EntityTypeConfiguration<Equipment>
    {
        public EquipmentMap()
        {        
            Property(t => t.EquipmentType).IsRequired();
            Property(t => t.EquipmentName).IsRequired();
        }
    }
}