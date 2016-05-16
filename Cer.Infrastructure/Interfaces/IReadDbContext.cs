using System.Data.Entity;
using Cer.Core.Abstractions;

namespace Cer.Infrastructure.Interfaces
{
    public interface IReadDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
    }
}