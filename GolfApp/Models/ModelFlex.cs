using System;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class ModelFlex
    {
        [Key]
        [Required]
        public int modelFlexID { get; set; }
        public string modelFlexName { get; set; }
    }
}
