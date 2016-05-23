namespace Cer.Infrastructure.Data.EfProvider.Interfaces
{
    public interface IWriteDbContext
    {
        int SaveChanges();
    }
}