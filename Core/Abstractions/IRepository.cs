using System.Collections.Generic;
using Cer.Core.Models;

namespace Cer.Core.Abstractions
{
    public interface IRepository<T, in TI> : IReadRepository<T, TI>, IWriteRepository<T> where T : IIdentifiableEntity<TI>
    {
    }

    public interface IReadRepository<out T, in TI> : IListRepository<T>, IIdentifyRepository<T, TI> where T : IIdentifiableEntity<TI>
    {
    }

    public interface IWriteRepository<in T> : IDeleteRepository<T>, IUpdateRepository<T>, ICreateRepository<T>
    {
    }

    public interface IIdentifyRepository<out T, in TI> where T : IIdentifiableEntity<TI>
    {
        T GetById(TI id);
    }

    public interface IListRepository<out T>
    {
        IEnumerable<T> List();
    }

    public interface IDeleteRepository<in T>
    {
        void Delete(T item);
    }
}