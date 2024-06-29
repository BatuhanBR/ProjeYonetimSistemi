using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjeYonetimSistemi.UI.MVC.Models

{
    public class LoginViewModel
    {
        public IdentityUser Email { get; internal set; }
        public string Password { get; internal set; }
       
        public bool RememberMe { get; internal set; }

    }
    
     

    
namespace IdentityMvcApp.Models
    {
        public class LoginViewModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
    }

}

 
