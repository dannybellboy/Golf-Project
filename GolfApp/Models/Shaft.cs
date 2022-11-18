using System;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class Shaft
    {
        [Key]
        [Required]
        public int shaftID { get; set; }
        public string shaftName { get; set; }
        public string length { get; set; }
    }
}

