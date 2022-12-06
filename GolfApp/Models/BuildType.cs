using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class BuildType
    {
        [Key]
        [Required]
        public int typeID { get; set; }
        public string typeName { get; set; }

    }
}

