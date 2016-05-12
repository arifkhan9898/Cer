using System.Data.Entity.ModelConfiguration;
using Cer.Core.Models;

namespace Cer.Infrastructure.Mapping
{
    public class RentStateMap : EntityTypeConfiguration<RentState>
    {
        public RentStateMap()
        {
            Property(t => t.State).IsRequired();
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
        }
    }
}
