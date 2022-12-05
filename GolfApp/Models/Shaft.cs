using Microsoft.AspNetCore.Http;
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
        public string imageName { get; set; }
        [Display(Name="Choose the image for the product")]
        public IFormFile shaftImage { get; set; }
        public string imagePath { get; set; }
        public double price { get; set; }

    }
}



