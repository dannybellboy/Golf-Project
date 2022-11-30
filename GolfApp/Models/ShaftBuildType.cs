using System;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class ShaftBuildType
    {
        [Key]
        [Required]
        public string shaftBuildType { get; set; }
       
        //Build Foreign Keys with shaft and type
        public int shaftID { get; set; }
        public Shaft shaft { get; set; }

        public int typeID { get; set; }
        public Type type { get; set; }


    }
}

