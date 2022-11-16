using System;
namespace GolfApp.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumEquipment { get; set; }
        public int EquipmentPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int startPage { get; set; }
        public int endPage { get; set; }
        public int LinksPerPage { get; set; }
        public string UrlParams { get; set; }

        //Num pages needed
        public int TotalPages => (int)Math.Ceiling((double)TotalNumEquipment / EquipmentPerPage);
    }
}
