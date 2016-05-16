using System.Data.Entity;
using Cer.Core.Abstractions;

namespace Cer.Infrastructure.Interfaces
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
