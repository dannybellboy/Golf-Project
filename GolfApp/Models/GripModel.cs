using System;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class GripModel
    {
        [Key]
        [Required]
        public int gripID { get; set; }
        //Build Foreign Key with brand
        public int brandID { get; set; }
        public Brand brand { get; set; }
        
    }
}

