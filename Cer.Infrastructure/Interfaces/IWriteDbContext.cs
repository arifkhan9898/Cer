namespace Cer.Infrastructure.Interfaces
{
    public interface IWriteDbContext
    {
        int SaveChanges();
    }
}