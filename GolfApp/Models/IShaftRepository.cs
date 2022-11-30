using System;
using System.Linq;

namespace GolfApp.Models
{
    public interface IShaftRepository
    {
        IQueryable<Shaft> shaft { get; }
    }
}
