using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class ShaftBrandModelFlex
    {
        [Key]
        [Required]
        public int sbmfID { get; set; }
        //foreign key relationships
        public int shaftID { get; set; }
        public Shaft shaft { get; set; }
        public int modelFlexID { get; set; }
        public ModelFlex modelflex { get; set; }
        public int brandID { get; set; }
        public Brand brand { get; set; }

    }
}
