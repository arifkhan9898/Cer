using Cer.Core.Abstractions;

namespace Cer.Core.Models
{
    public class RentState : IIdentifiableEntity<int>
    {
        public int RentStateId { get; set; }
        public string State { get; set; }

        public int EntityId
        {
            get { return RentStateId; }
            set { RentStateId = value; }
        }
    }
}