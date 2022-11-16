using System;
using System.Linq;

namespace GolfApp.Models
{
    public interface IEquipmentRepository
    {
        IQueryable<Equipment> equipment { get; }
    }
}
