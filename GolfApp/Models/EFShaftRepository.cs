using System;
using System.Linq;

namespace GolfApp.Models
{
    public class EFShaftRepository : IShaftRepository
    { 
        private ShaftDbContext _context { get; set; }

        public EFShaftRepository(ShaftDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Shaft> shaft => _context.shaft;
    }
}
