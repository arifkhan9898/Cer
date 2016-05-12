using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Cer.Core.Abstractions;
using Cer.Core.Models;

namespace Cer.Infrastructure
{
    public class CerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EquipmentItem> EquipmentItems { get; set; }
        public DbSet<RentItem> RentItems { get; set; }
        public DbSet<RentState> RentStates { get; set; }
        public DbSet<RentEquipmentItem> RentEquipmentItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IIdentifiableEntity<int>>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
