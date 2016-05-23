using Cer.Core.Models;
using Cer.Infrastructure.Business.Service.Implementations;

namespace Cer.Infrastructure.Business.Service.Specifications
{
    public class CartEquipmentByCartIdSpecification : Specification<CartEquipment>
    {
        public CartEquipmentByCartIdSpecification(long cartId)
            : base(cartEquipment => cartEquipment.CartId == cartId) { }
    }
    //public class CartEquipmentByCartIdSpecification : Specification<CartEquipment, long>
    //{
    //    public CartEquipmentByCartIdSpecification()
    //        : base((cartEquipment, cartId) => cartEquipment.CartId == cartId)
    //    { }
    //}
}