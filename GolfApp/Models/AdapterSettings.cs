using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class AdapterSettings
    {
        [Key]
        [Required]
        public int adapterID { get; set; }
        public string adapterName { get; set; }
        public string adapterSettings { get; set; }
        //Build Foreign Key with brand
        public int brandID { get; set; }
        public Brand brand { get; set; }
    }
}

