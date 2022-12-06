using System.Linq;

namespace GolfApp.Models.ViewModels
{
    public class ShaftViewModel
    {
        public IQueryable<Shaft> shaft { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}
