using GolfApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


public partial class BufferedSingleFileUploadDbModel : PageContext
{ 
    [BindProperty]
    public BufferedSingleFileUploadDbModel FileUpload { get; set; }
       
}
