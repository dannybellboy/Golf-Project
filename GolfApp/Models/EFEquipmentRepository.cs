using System;
using System.Linq;

namespace GolfApp.Models
{
    public class EFEquipmentRepository : IEquipmentRepository
    { 
        private EquipmentDbContext _context { get; set; }

        public EFEquipmentRepository(EquipmentDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Equipment> equipment => _context.equipment;
    }
}
