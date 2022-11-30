using System;
using Microsoft.EntityFrameworkCore;

namespace GolfApp.Models
{
    public class EquipmentDbContext : DbContext
    {
        public EquipmentDbContext(DbContextOptions<EquipmentDbContext> options) : base(options)
        {

        }

        public DbSet<Shaft> shaft { get; set; }

        
    }
}
