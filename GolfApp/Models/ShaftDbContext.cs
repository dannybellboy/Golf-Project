using System;
using Microsoft.EntityFrameworkCore;

namespace GolfApp.Models
{
    public class ShaftDbContext : DbContext
    {
        public ShaftDbContext(DbContextOptions<ShaftDbContext> options) : base(options)
        {

        }

        public DbSet<Shaft> shaft { get; set; }
    }
}
