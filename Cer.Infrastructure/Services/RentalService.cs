using System;
using System.Collections.Generic;
using System.Linq;
using Cer.Core.Abstractions;
using Cer.Core.DataTransferObjects;
using Cer.Core.Interfaces;
using Cer.Core.Models;
using Cer.Core.Services;

namespace Cer.Infrastructure.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRepository<RentState> _rentStates;
        private readonly IRepository<RentCart> _rentItems;
        private readonly IRepository<RentEquipmentItem> _rentEquipmentItems;
        private readonly IRepository<EquipmentItem> _equipmentItems;

        public RentalService(
            IRepository<RentState> rentStates,
            IRepository<RentCart> rentItems,
            IRepository<RentEquipmentItem> rentEquipmentItems,
            IRepository<EquipmentItem> equipmentItems)
        {
            _rentStates = rentStates;
            _rentItems = rentItems;
            _rentEquipmentItems = rentEquipmentItems;
            _equipmentItems = equipmentItems;
        }

        public IEnumerable<EquipmentItem> GetAvailableEquipmentItems()
        {
            return _equipmentItems.List;//.Where(o => o.RentEquipmentItems.All(k => k.ReturnDate != null));
        }

        public RentCart SubmitOrder(int[] ids)
        {
            ids.Select(o => _equipmentItems.GetById(o));
            return null;
        }

        public InvoiceDto GetInvoice(RentCart rentItemId)
        {
            throw new NotImplementedException();
        }
    }
}
