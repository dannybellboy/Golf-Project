using System;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class OrderLineItem
    {
        [Key]
        [Required]
        public int orderID { get; set; }
        public int quantity { get; set; }
        public DateTime date { get; set; }
        // foreign key relationship
        public int customID { get; set; }
        public CustomProduct customproduct { get; set; }
    }
}
