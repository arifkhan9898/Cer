using Cer.Core.Abstractions;

namespace Cer.Core.Models
{
    public class Customer : IIdentifiableEntity<int>
    {
        public int CustomerId { get; set; }
        public string Nickname { get; set; }

        public int EntityId
        {
            get { return CustomerId; }
            set { CustomerId = value; }
        }
    }
    public interface ICreateRepository<in T>
    {
        void Create(T item);
    }

    public interface IUpdateRepository<in T>
    {
        void Update(T item);
    }
}