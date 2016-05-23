using System.Data.Entity.Migrations;
using Cer.Core.Models;
using Cer.Infrastructure.Data.EfProvider.Contextes;
using Cer.Infrastructure.Data.EfProvider.Data;

namespace Cer.Infrastructure.Data.EfProvider.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contextes.CerDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            var seed = new SampleData();
            context.Set<User>().AddOrUpdate(x => x.Id, seed.Users.ToArray());
            context.Set<Equipment>().AddOrUpdate(x => x.Id, seed.Equipments.ToArray());
            context.Set<Cart>().AddOrUpdate(x => x.Id, seed.Carts.ToArray());
            context.Set<CartEquipment>().AddOrUpdate(x => x.Id, seed.CartEquipments.ToArray());
        }
    }
}
