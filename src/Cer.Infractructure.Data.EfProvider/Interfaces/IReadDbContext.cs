using System.Data.Entity;
using Cer.Core.Abstractions;

namespace Cer.Infrastructure.Data.EfProvider.Interfaces
{
    public interface IReadDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
    }
}