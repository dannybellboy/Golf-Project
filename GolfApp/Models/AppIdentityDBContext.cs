using System;
using Microsoft.AspNetCore.Identity;

namespace GolfApp.Models
{
    public class AppIdentityDBContext : IdentityDBContext<IdentityUser>
    {
        public AppIdentityDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}

