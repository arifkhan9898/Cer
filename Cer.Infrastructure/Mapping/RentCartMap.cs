using System.Data.Entity.ModelConfiguration;
using Cer.Core.Models;

namespace Cer.Infrastructure.Mapping
{
    public class RentCartMap : EntityTypeConfiguration<RentCart>
    {
        public RentCartMap()
        {
            Property(t => t.RentDurationDays).IsRequired();
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
        }
    }
}