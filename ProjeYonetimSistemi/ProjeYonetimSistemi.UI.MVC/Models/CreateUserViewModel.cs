using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjeYonetimSistemi.UI.MVC.Models; 


namespace ProjeYonetimSistemi.UI.MVC.Models
{
    public class CreateUserViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
