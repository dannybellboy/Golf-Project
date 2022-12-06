using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


public partial class BufferedSingleFileUploadDbModel : PageContext
{
    [BindProperty]
    public BufferedSingleFileUploadDbModel FileUpload { get; set; }

}
