using System;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class Order1
    {
        [Key]
        [Required]
        public int orderID { get; set; }

    }
}
