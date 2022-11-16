using System;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class Equipment
    {
        [Key]
        [Required]
        public string Reference_Handle { get; set; }
        public string Token { get; set; }
        public string Item_Name { get; set; }
        public string Variation_Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Option_Name_1 { get; set; }
        public string Option_Value_1 { get; set; }
        public string Current_Quantity_The_Club_Fix_of_Texas { get; set; }
        public string New_Quantity_The_Club_Fix_of_Texas { get; set; }
        public string Stock_Alert_Enabled_The_Club_Fix_of_Texas { get; set; }
        public string Tax_TEXAS_825 { get; set; }
    }
}
