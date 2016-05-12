using System.Collections.Generic;
using System.Linq;
using Cer.Core.Abstractions;
using Cer.Core.Models;

namespace Cer.Infrastructure.Services
{
    public class EfEquipmentItemReadRepository : IReadRepository<EquipmentItem, int>
    {
        private readonly CerDbContext _cerDbContext;

        public EfEquipmentItemReadRepository(CerDbContext cerDbContext)
        {
            _cerDbContext = cerDbContext;
        }

        public IEnumerable<EquipmentItem> List()
        {
            return _cerDbContext.EquipmentItems;
        }

        public EquipmentItem GetById(int id)
        {
            return _cerDbContext.EquipmentItems.FirstOrDefault(o => o.EquipmentItemId == id);
        }
    }
}
