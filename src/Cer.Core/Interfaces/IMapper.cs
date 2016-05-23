using System;

namespace Cer.Core.Interfaces
{
    public interface IMapper<in TI1, out TO>
    {
        Func<TI1, TO> Create { get; }
    }
    public interface IMapper<in TI1, in TI2, out TO>
    {
        Func<TI1, TI2, TO> Create { get; }
    }
}
