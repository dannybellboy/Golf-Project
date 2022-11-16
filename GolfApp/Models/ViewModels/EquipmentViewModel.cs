using System;
using System.Linq;

namespace GolfApp.Models.ViewModels
{
    public class EquipmentViewModel
    {
        public IQueryable<Equipment> equipment { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}
