using System;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public String Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}

