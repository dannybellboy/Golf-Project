using System;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class Brand
    {
        [Key]
        [Required]
        public int brandID { get; set; }
        public string brandName { get; set; }
    }
}

