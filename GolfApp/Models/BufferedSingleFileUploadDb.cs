using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
