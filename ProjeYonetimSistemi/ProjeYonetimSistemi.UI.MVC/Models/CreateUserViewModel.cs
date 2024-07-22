using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjeYonetimSistemi.UI.MVC.Models; 


namespace ProjeYonetimSistemi.UI.MVC.Models
{
    public class CreateUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } // Ek bir alan olarak e-posta ekleyebilirsiniz.
        public string Password { get; set; } // Şifre ekleyebilirsiniz.
        public List<ApplicationUser> Users { get; set; } // Mevcut kullanıcıları listelemek için
    }
}
