using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class CustomProduct
    {
        [Key]
        [Required]
        public int customID { get; set; }
        //foreign key relationships
        public int sbmfID { get; set; }
        public ShaftBrandModelFlex shaftbrandmodelflex { get; set; }
        public int buildType { get; set; }
        public int adapterSettings { get; set; }
        public AdapterSettings adaptersettings { get; set; }
        public int gripModel { get; set; }
        public GripModel gripmodel { get; set; }



    }
}
